namespace Application.DTOs;
public class TopicDTO
{
    public Guid Id { get; set; }
    public string TopicTitle { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool IsFinished { get; set; }
}

public class CreateTopicDTO
{
    public string TopicTitle { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public bool IsFinished { get; set; }
    public Guid CourseId { get; set; }
}