using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MakoSystems.Sovienation.GameCore;

namespace MakoSystems.Sovienation.Network;

record TcpServerOptions
{
    public int Port { get; init; }
}

internal class TcpServer
{
    private readonly int _port;
    private readonly ILogger _logger;
    private Session _session;
    

    public TcpServer(
        IOptions<TcpServerOptions> options,
        ILogger<TcpServer> logger)
    {
        _port = options.Value.Port;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        // TODO: actually loading from database here
        _session = new Session();
    }

    public async Task RunServerAsync(CancellationToken cancellationToken = default)
    {
        TcpListener listener = new(IPAddress.Any, _port);
        _logger.LogInformation("Server listener started on port {0}",_port);
        listener.Start();

        while(true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using TcpClient client = await listener.AcceptTcpClientAsync();
            _logger.LogInformation("Client connected: {0}", client.Client.RemoteEndPoint);
            var _ = SendAsync(client, cancellationToken);
        }
    }

    private async Task SendAsync(TcpClient client, CancellationToken cancellationToken = default)
    {
        try
        {
            client.LingerState = new LingerOption(true, 10);
            client.NoDelay = true;

            using var stream = client.GetStream();

            // TODO: convert session data to bytes here.
            var buffer = _session.GetFrames().AsMemory();

            await stream.WriteAsync(buffer, cancellationToken);

            
        }
        catch(IOException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        catch(SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

}