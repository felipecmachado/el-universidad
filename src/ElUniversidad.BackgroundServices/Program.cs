using ElUniversidad.Application.Extensions;
using ElUniversidad.BackgroundServices.Configurations;
using ElUniversidad.Infrastructure.Data.Modules;
using ElUniversidad.Infrastructure.Data.Seeders;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services
            .AddAppServices()
            .AddDataInfrastructure(context.Configuration)
            .AddCQRSConfiguration()
            .AddWorkersConfiguration(context.Configuration);

        ElUniversidadInitializer.ElUniversidadInitializeAndSeed(services);
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
        logging.AddDebug();
    })
    .Build();

await host.RunAsync();