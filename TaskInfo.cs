namespace ClassLibrary
{
    public class TaskInfo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
    }
}
