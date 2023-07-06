using AutoMapper;

namespace CTF.Features.Session;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, Session>();
    }
}
