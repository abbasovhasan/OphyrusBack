namespace Domain.Models;

public class Topic : BaseEntity
{
    public string TopicTitle { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool IsFinished { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}