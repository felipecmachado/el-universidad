using AutoMapper;
using ElUniversidad.Application.Programs.Results;
using ElUniversidad.Domain.Programs;

namespace ElUniversidad.Application.Programs.Profiles
{
    public class OfferResultProfile : Profile
    {
        public OfferResultProfile()
        {
            CreateMap<Offer, OfferResult>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.PricePerCredit, opts => opts.MapFrom(src => src.PricePerCredit))
                .ForMember(dest => dest.AdmissionsQuota, opts => opts.MapFrom(src => src.AdmissionsQuota))
                .ForMember(dest => dest.StartingOn, opts => opts.MapFrom(src => src.StartingOn))
                .ForMember(dest => dest.AdmissionAvailableUntil, opts => opts.MapFrom(src => src.AdmissionAvailableUntil))
                .ForMember(dest => dest.CreatedAt, opts => opts.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.ProgramStructure, opts => opts.MapFrom(src => src.ProgramStructure));

            CreateMap<IList<Offer>, OffersResult>()
                .ForMember(dest => dest.Offers, c => c.MapFrom(src => src));
        }
    }
}