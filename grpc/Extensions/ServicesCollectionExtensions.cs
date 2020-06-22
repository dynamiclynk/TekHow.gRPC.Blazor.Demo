using Microsoft.Extensions.DependencyInjection;
using TekHow.RabbitMq;
using TekHow.RabbitMq.Types;

public static class ServicesCollectionExtensions
{

    public static IServiceCollection AddMessageQueuing(this IServiceCollection services)
    {
        QueueExchangeCreationOptions[] queueExchangeCreationOptions = { new QueueExchangeCreationOptions("grpc-messaging", "grpc-messaging") };
        var ctlr = new QueuingController("amqp:///","grpc-server", queueExchangeCreationOptions);
        ctlr.CreateQueueExchangeBindings(queueExchangeCreationOptions);
        services.AddSingleton(typeof(QueuingController),ctlr);
        return services;
    }

}