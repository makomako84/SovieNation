using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MakoSystems.Sovienation.Application;
using MakoSystems.Sovienation.Host;
using MakoSystems.Sovienation.GameCore;
using MakoSystems.Sovienation.Persist;
using MakoSystems.Sovienation.DTO;
using MakoSystems.Sovienation.Network;
using AutoMapper;
using MakoSystems.Sovienation.Mapper;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config => 
    {
        // .. optional here
        // config.SetBasePath(Directory.GetCurrentDirectory());
        // config
        //     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    // .ConfigureLogging((context, logging) =>
    // {
    //     // logging.ClearProviders();
    //     // logging.AddConsole();
    // })
    .ConfigureServices((context,services) => 
    {
        // .. get configuration
        IConfiguration config = context.Configuration;

        MapperRegister.RegisterAutoMapper(services);

        // configure di here ...
        services.Configure<TestOptions>(config.GetSection(nameof(TestOptions)));
        services.Configure<TcpServerOptions>(config.GetSection("TcpServer"));
        

        // services here ..
        services.AddTransient<TestService>(); 
        services.AddTransient<TcpServer>();
        

        // persistence services
        services.AddSingleton<IRoomRepository, RoomRepository>();

        // application services services
        //services.AddSingleton<RoomBackupWorker>();
    })
    .Build();

// .. test service here ...
var testService = host.Services.GetRequiredService<TestService>();
testService.TestValues();

// Test initialize

// var backupService = host.Services.GetRequiredService<RoomBackupWorker>();
// backupService.Backup();

// var testLaunch = new TestLaunch();
// testLaunch.LaunchGameSession();


// decoment to set for await ...
// await host.RunAsync();


var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger("TcpServer");
CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    logger.LogInformation("cancellation initiated");
    cancellationTokenSource.Cancel();
};

try
{
    var service = host.Services.GetRequiredService<TcpServer>();
    await service.InitializeAsync();
    await service.RunServerAsync(cancellationTokenSource.Token);
}
catch(Exception ex)
{
    logger.LogError(ex, ex.Message);
    Environment.Exit(-1);
}
Console.ReadLine();