using Application.Abstraction.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHackAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    // Tüm öğretmenleri listele
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDTO>>> GetAllTeachers()
    {
        var teachers = await _teacherService.GetAllTeachersAsync(); // Servisten tüm öğretmenleri al
        return Ok(teachers); // Öğretmenleri başarılı bir şekilde döndür
    }

    // Öğretmeni ID ile getir
    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDTO>> GetTeacherById(Guid id)
    {
        var teacher = await _teacherService.GetTeacherByIdAsync(id); // Servisten ID'ye göre öğretmeni al
        if (teacher == null)
            return NotFound(); // Eğer öğretmen bulunamazsa, 404 döndür
        return Ok(teacher); // Öğretmeni başarılı bir şekilde döndür
    }

    // Yeni öğretmen ekle
    [HttpPost]
    public async Task<ActionResult> AddTeacher(CreateTeacherDTO createTeacherDTO)
    {
        // Yeni öğretmeni ekliyoruz
        Guid Id = await _teacherService.AddTeacherAsync(createTeacherDTO);


        // Öğretmen başarıyla oluşturulduysa, 201 Created döndür
        return CreatedAtAction(nameof(GetTeacherById), new { id = Id });
    }
    // Öğretmeni güncelle
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateTeacher(Guid id, CreateTeacherDTO updateTeacherDTO)
    {
        // Servise öğretmeni güncellemesi için çağrı yap
        await _teacherService.UpdateTeacherAsync(id, updateTeacherDTO);

        // Güncellenen öğretmeni döndürüyoruz
        return NoContent(); // 204 No Content döndürüyoruz çünkü veriyi döndürmüyoruz
    }

    // Öğretmeni sil
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTeacher(Guid id)
    {
        await _teacherService.DeleteTeacherAsync(id); // Servise öğretmeni silmesi için çağrı yap

        return NoContent(); // Öğretmen başarıyla silindi, 204 döndür
    }
}

