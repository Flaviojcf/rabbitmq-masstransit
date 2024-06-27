namespace MessageBus.API.Models
{
    public static class ListReports
    {
        public static List<Report> Reports { get; set; } = [];
    }

    public class Report
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime? ProcessedTime { get; set; }
    }
}
