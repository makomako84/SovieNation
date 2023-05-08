using MakoSystems.NetworkTransfer;
using MakoSystems.Sovienation.Mapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var settings = context.Configuration;

        MapperRegister.RegisterAutoMapper(services);

        services.Configure<ClientOptions>(settings.GetSection("Client"));
        services.AddTransient<Client>();
    })
    .Build();

var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Client");

CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    logger.LogInformation("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};

var client = host.Services.GetRequiredService<Client>();
await client.SendAndReceiveAsync(cancellationTokenSource.Token);


record ClientOptions
{
    public string? Hostname { get; init; }
    public int ServerPort { get; init; }
}

class Client
{
    private readonly string _hostname;
    private readonly int _serverPort;
    private readonly ILogger _logger;
    public Client(IOptions<ClientOptions> options, ILogger<Client> logger)
    {
        _hostname = options.Value.Hostname ?? "localhost";
        _serverPort = options.Value.ServerPort;
        _logger = logger;
    }

    public async Task SendAndReceiveAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Memory<byte> buffer = new byte[4096].AsMemory();
            string? line;
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine(@"Press enter to read a quote, ""bye"" to exit");
                line = Console.ReadLine();
                if (line?.Equals("bye", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    repeat = false;
                }
                else
                {
                    TcpClient client = new();
                    await client.ConnectAsync(_hostname, _serverPort, cancellationToken);
                    using var stream = client.GetStream(); 
                    int bytesRead = await stream.ReadAsync(buffer, cancellationToken);

                    Frame frame = Frame.Parser.ParseFrom(buffer.ToArray(), 0, bytesRead);


                    //string quote = Encoding.UTF8.GetString(buffer.Span[..bytesRead]);
                    //buffer.Span[..bytesRead].Clear();


                    Console.WriteLine(frame);
                    Console.WriteLine();
                }
            };
        }
        catch (SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        Console.WriteLine("so long, and thanks for all the fish");
    }
}
