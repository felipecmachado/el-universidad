using AutoMapper;
using ElUniversidad.Application.Courses.Results;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs;

namespace ElUniversidad.Application.Programs.Profiles
{
    public class ProgramStructureResultProfile : Profile
    {
        public ProgramStructureResultProfile()
        {
            CreateMap<AssignedCourse, CourseResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Course.Id))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Course.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Course.Description))
                .ForMember(dest => dest.AdditionalInformation, opts => opts.MapFrom(src => src.Course.AdditionalInformation))
                .ForMember(dest => dest.MinimumGrade, opts => opts.MapFrom(src => src.Course.MinimumGrade))
                .ForMember(dest => dest.Credits, opts => opts.MapFrom(src => src.Course.Credits))
                .ForMember(dest => dest.Hours, opts => opts.MapFrom(src => src.Course.Hours));

            CreateMap<ProgramStructure, ProgramStructureResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProgramId, opts => opts.MapFrom(src => src.ProgramId))
                .ForMember(dest => dest.ProgramTitle, opts => opts.MapFrom(src => src.Program.Title))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.AssignedCourses, opts => opts.MapFrom(src => src.Courses))
                .AfterMap((src, dest) =>
                {
                    dest.TotalHours = dest.AssignedCourses.Sum(x => x.Hours);
                    dest.TotalCredits = dest.AssignedCourses.Sum(x => x.Credits);
                });

            CreateMap<IList<ProgramStructure>, ProgramStructuresResult>()
                .ForMember(dest => dest.ProgramStructures, c => c.MapFrom(src => src));
        }
    }
}