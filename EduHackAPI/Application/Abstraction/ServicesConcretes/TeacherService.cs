using Application.Abstraction.Repositories;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.Abstraction.Services;

public class TeacherService : ITeacherService
{
    private readonly IRepository<Teacher> _teacherRepository;
    private readonly IMapper _mapper;

    public TeacherService(IRepository<Teacher> teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task AddTeacherAsync(CreateTeacherDTO createTeacherDTO)
    {
        var teacher = _mapper.Map<Teacher>(createTeacherDTO); // DTO'dan Teacher modeline dönüştür
        await _teacherRepository.AddAsync(teacher); // Öğretmeni veritabanına ekle

        // Veritabanına eklenen öğretmeni almak
        var addedTeacher = await _teacherRepository.GetByIdAsync(teacher.Id); // ID'yi al
    }

    // Tüm öğretmenleri listele
    public async Task<IEnumerable<TeacherDTO>> GetAllTeachersAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync(); // Veritabanından öğretmenleri al
        return _mapper.Map<IEnumerable<TeacherDTO>>(teachers); // Öğretmenleri DTO'ya dönüştür
    }

    // Teacher ID ile getir
    public async Task<TeacherDTO> GetTeacherByIdAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id); // Veritabanından öğretmeni al
        return _mapper.Map<TeacherDTO>(teacher); // Öğretmeni DTO'ya dönüştür
    }


    // Yeni Teacher ekl

    // Teacher güncelle
    public async Task UpdateTeacherAsync(Guid id, CreateTeacherDTO updateTeacherDTO)
    {
        var teacher = _mapper.Map<Teacher>(updateTeacherDTO); // DTO'dan Teacher modeline dönüştür
        teacher.Id = id; // ID'yi güncelle
        await _teacherRepository.UpdateAsync(teacher); // Öğretmeni veritabanında güncelle
    }

    // Teacher sil
    public async Task DeleteTeacherAsync(Guid id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id); // ID'ye göre öğretmeni al
        if (teacher != null)
        {
            await _teacherRepository.DeleteAsync(teacher); // Öğretmeni veritabanından sil
        }
    }

    // Öğretmenleri bir şart ile ara
    public async Task<IEnumerable<Teacher>> FindAsync(Expression<Func<Teacher, bool>> predicate)
    {
        return await _teacherRepository.FindAsync(predicate); // Predicate'a göre öğretmenleri ara
    }

    // Öğretmeni ID'ye göre al
    public async Task<Teacher> GetByIdAsync(Guid id)
    {
        return await _teacherRepository.GetByIdAsync(id); // Teacher ID'ye göre al
    }

    // Öğretmenleri listele
    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _teacherRepository.GetAllAsync(); // Tüm öğretmenleri listele
    }

    // Öğretmenleri DTO formatında getir
    public async Task<IEnumerable<TeacherDTO>> GetTeachersAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync(); // Öğretmenleri veritabanından al
        return _mapper.Map<IEnumerable<TeacherDTO>>(teachers); // Öğretmenleri DTO'ya dönüştür
    }

    // Öğrencileri ekleme (İService<T> üzerinden gelen metot)
    public async Task AddAsync(Teacher entity)
    {
        await _teacherRepository.AddAsync(entity); // Öğretmeni veritabanına ekle
    }

    // Öğrenciyi güncelleme (İService<T> üzerinden gelen metot)
    public async Task UpdateAsync(Teacher entity)
    {
        await _teacherRepository.UpdateAsync(entity); // Öğretmeni veritabanında güncelle
    }

    // Öğrenciyi silme (İService<T> üzerinden gelen metot)
    public async Task DeleteAsync(Teacher entity)
    {
        await _teacherRepository.DeleteAsync(entity); // Öğretmeni veritabanından sil
    }
}