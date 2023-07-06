using AutoMapper;

namespace CTF.Features.TransactionType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, TransactionType>();
    }
}
