using AutoMapper;

namespace CTF.Features.TransactionDefinition;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, Get>();
        CreateMap<SaveCommand, TransactionDefinition>();
    }
}
