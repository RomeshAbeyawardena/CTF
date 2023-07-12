using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.ActivityLog;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.ActivityLog, Models.ActivityLog>();
        CreateMap<Models.ActivityLog, CTF.Features.Models.ActivityLog>()
            .ReverseMap();
    }
}
