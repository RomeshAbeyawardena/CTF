using AutoMapper;

namespace CTF.Features.ActivityType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, Models.ActivityType>();
    }
}
