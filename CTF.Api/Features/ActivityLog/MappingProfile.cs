using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.ActivityLog;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.ActivityLog, ActivityLog>();
        CreateMap<ActivityLog, CTF.Features.Models.ActivityLog>()
            .ReverseMap();
    }
}
