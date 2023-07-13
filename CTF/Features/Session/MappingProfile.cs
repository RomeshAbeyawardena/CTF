using AutoMapper;

namespace CTF.Features.Session;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.Session>();
    }
}
