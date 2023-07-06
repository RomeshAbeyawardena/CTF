using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Session;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Session.Session, Session>();
        CreateMap<Session, CTF.Features.Session.Session>()
            .ReverseMap();
    }
}
