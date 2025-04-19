using Application.Abstraction.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TopicController : ControllerBase
{
    private readonly TopicService _topicService;

    public TopicController(TopicService topicService)
    {
        _topicService = topicService;
    }

    // Tüm topicleri listele
    [HttpGet]
    public async Task<IActionResult> GetTopics()
    {
        var topics = await _topicService.GetAllTopicsAsync();
        return Ok(topics);
    }

    // Topic ekle
    [HttpPost]
    public async Task<IActionResult> AddTopic([FromBody] CreateTopicDTO createTopicDTO)
    {
        await _topicService.AddTopicAsync(createTopicDTO);
        return Ok();
    }

    // Topic güncelle
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTopic(Guid id, [FromBody] CreateTopicDTO updateTopicDTO)
    {
        await _topicService.UpdateTopicAsync(id, updateTopicDTO);
        return Ok();
    }

    // Topic sil
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTopic(Guid id)
    {
        await _topicService.DeleteTopicAsync(id);
        return Ok();
    }
}
