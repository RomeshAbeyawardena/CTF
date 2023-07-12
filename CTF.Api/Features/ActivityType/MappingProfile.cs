using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.ActivityType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.ActivityType, Models.ActivityType>();
        CreateMap<Models.ActivityType, CTF.Features.Models.ActivityType>()
            .ReverseMap();
    }
}
