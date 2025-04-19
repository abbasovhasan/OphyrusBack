using Application.Abstraction.Services;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EduHackAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // Tüm öğrencileri listele
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
    {
        var students = await _studentService.GetAllStudentsAsync(); // Servisten tüm öğrencileri al
        return Ok(students); // Öğrencileri başarılı bir şekilde döndür
    }

    // Öğrenciyi ID ile getir
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudentById(Guid id)
    {
        var student = await _studentService.GetStudentByIdAsync(id); // Servisten ID'ye göre öğrenciyi al
        if (student == null)
            return NotFound(); // Eğer öğrenci bulunamazsa, 404 döndür
        return Ok(student); // Öğrenciyi başarılı bir şekilde döndür
    }

    // Öğrenciyi güncelle
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(Guid id, CreateStudentDTO updateStudentDTO)
    {
        await _studentService.UpdateStudentAsync(id, updateStudentDTO); // Servise öğrenci güncellemesi için çağrı yap
        return NoContent(); // Öğrenci güncellendikten sonra 204 No Content döndürüyoruz
    }

    // Öğrenciyi sil
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        await _studentService.DeleteStudentAsync(id); // Servise öğrenci silme işlemi için çağrı yap
        return NoContent(); // Öğrenci başarıyla silindi, 204 döndür
    }

    [HttpPost]
    public async Task<ActionResult> AddStudent(CreateStudentDTO createStudentDTO)
    {
        Guid Id = await _studentService.AddStudentAsync(createStudentDTO); // Servise yeni öğrenci ekleme işlemi için çağrı yap

        return CreatedAtAction(nameof(GetStudentById), new { id = Id }); // Yeni öğrenci başarıyla eklendi, 201 döndür
    }
}
