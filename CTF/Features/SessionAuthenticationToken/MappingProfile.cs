using AutoMapper;

namespace CTF.Features.SessionAuthenticationToken;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.SessionAuthenticationToken>();
    }
}
