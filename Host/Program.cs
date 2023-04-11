using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MakoSystems.Sovienation.Application;
using MakoSystems.Sovienation.Host;
using MakoSystems.Sovienation.GameCore;
using MakoSystems.Sovienation.Persist;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(config => 
    {
        // .. optional here
        // config.SetBasePath(Directory.GetCurrentDirectory());
        // config.AddJsonFile("custom.json", optional: true);
    })
    .ConfigureLogging((context, logging) =>
    {
        // logging.ClearProviders();
        // logging.AddConsole();
    })
    .ConfigureServices((context,services) => 
    {
        // .. get configuration
        IConfiguration config = context.Configuration;
        // configure di service example here ...
        services.Configure<TestOptions>(config.GetSection(key: nameof(TestOptions)));

        // .. optional services here ..
        services.AddTransient<TestService>(); 
        services.AddSingleton<RoomBackupWorker>();
        services.AddSingleton<IRoomSlice, RoomPool>();
        services.AddSingleton<IRoomRepository, RoomRepository>();
    })
    .Build();

// .. test service here ...
// var testService = host.Services.GetRequiredService<TestService>();
// testService.TestValues();

var backupService = host.Services.GetRequiredService<RoomBackupWorker>();
backupService.Backup();



// decoment to set for await ...
// await host.RunAsync();