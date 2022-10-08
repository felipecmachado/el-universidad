using AutoMapper;
using ElUniversidad.Application.Students.Results;
using ElUniversidad.Domain.Students;

namespace ElUniversidad.Application.Students.Profiles
{
    public class StudentsResultProfile : Profile
    {
        public StudentsResultProfile()
        {
            CreateMap<Student, StudentResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.BirthDate, opts => opts.MapFrom(src => src.BirthDate));

            CreateMap<IList<Student>, StudentsResult>()
                .ForMember(dest => dest.Students, c => c.MapFrom(src => src));
        }
    }
}