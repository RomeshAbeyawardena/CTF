using AutoMapper;

namespace CTF.Features.Client;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.Client>();
    }
}
