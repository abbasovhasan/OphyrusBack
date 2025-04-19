using Application.Abstraction.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHackAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    // Tüm kursları listele
    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    // Kurs ekle
    [HttpPost]
    public async Task<IActionResult> AddCourse([FromBody] CreateCourseDTO createCourseDTO)
    {
        await _courseService.AddCourseAsync(createCourseDTO);
        return Ok();
    }

    // Kurs güncelle
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] CreateCourseDTO updateCourseDTO)
    {
        await _courseService.UpdateCourseAsync(id, updateCourseDTO);
        return Ok();
    }

    // Kurs sil
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        await _courseService.DeleteCourseAsync(id);
        return Ok();
    }
}
