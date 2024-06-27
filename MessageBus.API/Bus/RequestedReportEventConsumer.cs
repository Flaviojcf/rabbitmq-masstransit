using MassTransit;
using MessageBus.API.Models;

namespace MessageBus.API.Bus
{
    public class RequestedReportEventConsumer : IConsumer<ReportRequestedEvent>
    {
        private readonly ILogger<RequestedReportEventConsumer> _logger;

        public RequestedReportEventConsumer(ILogger<RequestedReportEventConsumer> logger)
        {
            _logger = logger;
        }

        async Task IConsumer<ReportRequestedEvent>.Consume(ConsumeContext<ReportRequestedEvent> context)
        {
            var message = context.Message;
            _logger.LogInformation("Processing report Id:{ID}, Name:{Name}", message.Id, message.Name);

            await Task.Delay(10000);

            var report = ListReports.Reports.FirstOrDefault(x => x.Id == message.Id);

            if (report != null)
            {
                report.Status = "Completed";
                report.ProcessedTime = DateTime.Now;
            }


            _logger.LogInformation("Report processed Id:{ID}, Name:{Name}", message.Id, message.Name);
        }
    }
}
