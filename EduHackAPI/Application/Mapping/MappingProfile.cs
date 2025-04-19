using AutoMapper;
using Domain.Models;
using Application.DTOs;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Teacher -> TeacherDTO
            CreateMap<Teacher, TeacherDTO>().ReverseMap();
            // CreateTeacherDTO -> Teacher
            CreateMap<CreateTeacherDTO, Teacher>();

            // Student -> StudentDTO
            CreateMap<Student, StudentDTO>().ReverseMap();
            // CreateStudentDTO -> Student
            CreateMap<CreateStudentDTO, Student>();

            // Course -> CourseDTO
            CreateMap<Course, CourseDTO>().ReverseMap();
            // CreateCourseDTO -> Course
            CreateMap<CreateCourseDTO, Course>();

            // Topic -> TopicDTO
            CreateMap<Topic, TopicDTO>().ReverseMap();
            // CreateTopicDTO -> Topic
            CreateMap<CreateTopicDTO, Topic>();

            CreateMap<Course, CourseDTO>().ReverseMap();
            // CreateCourseDTO -> Course
            CreateMap<CreateCourseDTO, Course>();
        }
    }
}