using Application.DTOs;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface ICourseService 
    {
        Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
        Task<CourseDTO> GetCourseByIdAsync(Guid id);
        Task AddCourseAsync(CreateCourseDTO createCourseDTO);
        Task UpdateCourseAsync(Guid id, CreateCourseDTO updateCourseDTO);
        Task DeleteCourseAsync(Guid id);
    }
}
