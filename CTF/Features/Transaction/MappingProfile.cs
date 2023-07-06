using AutoMapper;

namespace CTF.Features.Transaction;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, Transaction>();
    }
}
