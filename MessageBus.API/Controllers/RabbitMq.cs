using MassTransit;
using MessageBus.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageBus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMq : ControllerBase
    {

        [HttpPost("{name}")]
        public async Task<IActionResult> Create(string name, IBus bus)
        {
            var report = new Report
            {
                Id = Guid.NewGuid(),
                Name = name,
                Status = "Pending",
                ProcessedTime = null
            };

            ListReports.Reports.Add(report);

            var eventRequest = new ReportRequestedEvent(report.Id, report.Name);

            await bus.Publish(eventRequest);

            return Ok(report);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ListReports.Reports);
        }
    }
}
