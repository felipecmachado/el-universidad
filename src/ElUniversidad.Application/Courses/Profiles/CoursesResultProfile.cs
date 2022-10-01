using AutoMapper;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Domain.Courses;

namespace ElUniversidad.Application.Courses.Profiles
{
    public class CoursesResultProfile : Profile
    {
        public CoursesResultProfile()
        {
            CreateMap<Course, CourseResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.MinimumGrade, opts => opts.MapFrom(src => src.MinimumGrade))
                .ForMember(dest => dest.Hours, opts => opts.MapFrom(src => src.Hours));

            CreateMap<IList<Course>, CoursesResult>()
                .ForMember(dest => dest.Courses, c => c.MapFrom(src => src));
        }
    }
}