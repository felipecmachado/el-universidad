using AutoMapper;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs;

namespace ElUniversidad.Application.Programs.Profiles
{
    public class ProgramsResultProfile : Profile
    {
        public ProgramsResultProfile()
        {
            CreateMap<Program, ProgramResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opts => opts.MapFrom(src => src.Code))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.Degree, opts => opts.MapFrom(src => src.Degree))
                .ForMember(dest => dest.HasOffers, opts => opts.MapFrom(src => src.Offers.Any()));

            CreateMap<IList<Program>, ProgramsResult>()
                .ForMember(dest => dest.Programs, c => c.MapFrom(src => src));
        }
    }
}