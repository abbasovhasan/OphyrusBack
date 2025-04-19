namespace Application.DTOs;
public class CourseDTO
{
    public Guid Id { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // StartTime ve EndTime'ı ekledik
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public List<TopicDTO> Topics { get; set; } = new();
}

public class CreateCourseDTO
{
    public string Image { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // StartTime ve EndTime'ı ekledik
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}