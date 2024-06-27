using MassTransit;
using MessageBus.API.Bus;

namespace MessageBus.API.Extensions
{
    public static class MessageBusExtensions
    {
        public static void AddMessageBusService(this IServiceCollection services)
        {
            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.AddConsumer<RequestedReportEventConsumer>();
                busConfiguration.UsingRabbitMq((ctx, config) =>
                {
                    config.Host(new Uri("amqp://localhost:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });
                    config.ConfigureEndpoints(ctx);
                });
            });
        }
    }
}
