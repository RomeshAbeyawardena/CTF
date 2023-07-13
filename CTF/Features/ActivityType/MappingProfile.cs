using AutoMapper;

namespace CTF.Features.ActivityType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.ActivityType>();
    }
}
