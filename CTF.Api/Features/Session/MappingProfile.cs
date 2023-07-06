using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Session;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Session, Session>();
        CreateMap<Session, CTF.Features.Models.Session>()
            .ReverseMap();
    }
}
