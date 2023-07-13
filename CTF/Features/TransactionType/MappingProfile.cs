using AutoMapper;

namespace CTF.Features.TransactionType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPaged, GetQuery>();
        CreateMap<SaveCommand, Models.TransactionType>();
    }
}
