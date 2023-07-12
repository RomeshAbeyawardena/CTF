using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Authentication;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Session, ActivityLog>();
        CreateMap<ActivityLog, CTF.Features.Models.Session>()
            .ReverseMap();
    }
}
