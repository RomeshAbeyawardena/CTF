using AutoMapper;

namespace CTF.Features.Authentication;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RenewSessionCommand, SessionAuthenticationToken.SaveCommand>()
            .ForMember(m => m.ValidTo, opt => opt.MapFrom(m => m.RenewalDate));
    }
}
