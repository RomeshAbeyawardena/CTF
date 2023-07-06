﻿using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Transaction;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Transaction, Transaction>();
        CreateMap<Transaction, CTF.Features.Models.Transaction>()
            .ReverseMap();
    }
}
