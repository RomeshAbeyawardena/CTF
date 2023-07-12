using AutoMapper;

namespace CTF.Features.Resource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.Resource>();
    }
}
