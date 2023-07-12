using AutoMapper;

namespace CTF.Features.Policy;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.Policy>();
    }
}
