using AutoMapper;

namespace CTF.Features.ActivityLog;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.ActivityLog>();
    }
}
