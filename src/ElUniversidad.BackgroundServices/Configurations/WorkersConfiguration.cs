using ElUniversidad.BackgroundServices.Workers;
using ElUniversidad.BackgroundServices.Workers.Abstractions;

namespace ElUniversidad.BackgroundServices.Configurations
{
    public static class WorkersConfiguration
    {
        public static IServiceCollection AddWorkersConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            /// For more information about the cron expressions
            /// you can visit the following repo: https://github.com/HangfireIO/Cronos

            //services.AddScheduledWorker<>(c =>
            //{
            //    c.TimeZoneInfo = TimeZoneInfo.Local;
            //    c.ShouldRunOnStartup = true;
            //    c.CronExpression = @"*/1 * * * *"; // every 1 minutes
            //});

            return services;
        }
    }
}