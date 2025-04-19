using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System.Linq.Expressions;

public class StudentService : IStudentService
{
    private readonly IRepository<Student> _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IRepository<Student> studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    // Tüm öğrencileri listele
    public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync(); // Öğrencileri veritabanından al
        return _mapper.Map<IEnumerable<StudentDTO>>(students); // Öğrencileri DTO'ya dönüştür
    }

    // Student ID ile getir
    public async Task<StudentDTO> GetStudentByIdAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id); // ID'ye göre öğrenciyi al
        return _mapper.Map<StudentDTO>(student); // Öğrenciyi DTO'ya dönüştür
    }

    // Öğrenci güncelle
    public async Task UpdateStudentAsync(Guid id, CreateStudentDTO updateStudentDTO)
    {
        var student = _mapper.Map<Student>(updateStudentDTO); // DTO'dan Student modeline dönüştür
        student.Id = id; // Öğrencinin ID'sini güncelle
        await _studentRepository.UpdateAsync(student); // Öğrenciyi veritabanında güncelle
    }

    // Öğrenci sil
    public async Task DeleteStudentAsync(Guid id)
    {
        var student = await _studentRepository.GetByIdAsync(id); // Öğrenciyi ID'ye göre al
        if (student != null)
        {
            await _studentRepository.DeleteAsync(student); // Öğrenciyi veritabanından sil
        }
    }

    // Öğrencileri bir şart ile ara
    public async Task<IEnumerable<Student>> FindAsync(Expression<Func<Student, bool>> predicate)
    {
        return await _studentRepository.FindAsync(predicate); // Predicate'a göre öğrencileri ara
    }

    // Öğrenciyi ID'ye göre al
    public async Task<Student> GetByIdAsync(Guid id)
    {
        return await _studentRepository.GetByIdAsync(id); // ID'ye göre öğrenciyi al
    }

    // Öğrencileri listele
    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _studentRepository.GetAllAsync(); // Tüm öğrencileri listele
    }

    // Öğrenciyi ekleme (İService<T> üzerinden gelen metot)
    public async Task AddAsync(Student entity)
    {
        await _studentRepository.AddAsync(entity); // Öğrenciyi veritabanına ekle
    }

    // Öğrenciyi güncelleme (İService<T> üzerinden gelen metot)
    public async Task UpdateAsync(Student entity)
    {
        await _studentRepository.UpdateAsync(entity); // Öğrenciyi veritabanında güncelle
    }

    // Öğrenciyi silme (İService<T> üzerinden gelen metot)
    public async Task DeleteAsync(Student entity)
    {
        await _studentRepository.DeleteAsync(entity); // Öğrenciyi veritabanından sil
    }

    public Task<Guid> AddStudentAsync(CreateStudentDTO createStudentDTO)
    {
        var student = _mapper.Map<Student>(createStudentDTO); // DTO'dan Student modeline dönüştür

        student.Id = Guid.NewGuid(); // Yeni bir ID oluştur

        _studentRepository.AddAsync(student); // Öğrenciyi veritabanına ekle

        return Task.FromResult(student.Id); // Yeni oluşturulan öğrencinin ID'sini döndür

    }
}