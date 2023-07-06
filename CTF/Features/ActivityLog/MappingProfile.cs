using AutoMapper;

namespace CTF.Features.ActivityLog;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, Models.ActivityLog>();
    }
}
