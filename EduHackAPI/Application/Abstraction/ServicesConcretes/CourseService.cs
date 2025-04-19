using Application.Abstraction.Repositories;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        // Tüm kursları listele
        public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync(); // Kursları veritabanından al
            return _mapper.Map<IEnumerable<CourseDTO>>(courses); // Kursları DTO'ya dönüştür
        }

        // Kurs ID ile getir
        public async Task<CourseDTO> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id); // Veritabanından kursu al
            return _mapper.Map<CourseDTO>(course); // Kursu DTO'ya dönüştür
        }

        // Yeni Kurs ekle
        public async Task AddCourseAsync(CreateCourseDTO createCourseDTO)
        {
            var course = _mapper.Map<Course>(createCourseDTO); // DTO'dan Course modeline dönüştür
            await _courseRepository.AddAsync(course); // Kursu veritabanına ekle
        }

        // Kurs güncelle
        public async Task UpdateCourseAsync(Guid id, CreateCourseDTO updateCourseDTO)
        {
            var course = _mapper.Map<Course>(updateCourseDTO); // DTO'dan Course modeline dönüştür
            course.Id = id; // Kursun ID'sini güncelle
            await _courseRepository.UpdateAsync(course); // Kursu veritabanında güncelle
        }

        // Kurs sil
        public async Task DeleteCourseAsync(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id); // ID'ye göre kursu al
            if (course != null)
            {
                await _courseRepository.DeleteAsync(course); // Kursu veritabanından sil
            }
        }

        // Kursları bir şart ile ara
        public async Task<IEnumerable<Course>> FindAsync(Expression<Func<Course, bool>> predicate)
        {
            return await _courseRepository.FindAsync(predicate); // Predicate'a göre kursları ara
        }

        // Kursu ID'ye göre al
        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await _courseRepository.GetByIdAsync(id); // Course ID'ye göre al
        }

        // Tüm kursları listele
        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync(); // Tüm kursları listele
        }

        // Kursları DTO formatında getir
        public async Task<IEnumerable<CourseDTO>> GetCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync(); // Veritabanından kursları al
            return _mapper.Map<IEnumerable<CourseDTO>>(courses); // DTO'ya dönüştür
        }

        // Course ekleme (IService<T> üzerinden gelen metot)
        public async Task AddAsync(Course entity)
        {
            await _courseRepository.AddAsync(entity); // Kursu veritabanına ekle
        }

        // Course güncelleme (IService<T> üzerinden gelen metot)
        public async Task UpdateAsync(Course entity)
        {
            await _courseRepository.UpdateAsync(entity); // Kursu veritabanında güncelle
        }

        // Course silme (IService<T> üzerinden gelen metot)
        public async Task DeleteAsync(Course entity)
        {
            await _courseRepository.DeleteAsync(entity); // Kursu veritabanından sil
        }
    }
}