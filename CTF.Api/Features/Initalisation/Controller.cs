using Microsoft.AspNetCore.Mvc;
using RST.DependencyInjection.Extensions;
using RST.DependencyInjection.Extensions.Attributes;
using System.Data;
using Dapper;
using MediatR;
using CTF.Features.Initialisation;
using AutoMapper;

namespace CTF.Api.Features.Initalisation;

[ApiController]
public class Controller : EnableInjectionBase<InjectAttribute>
{
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpPost] 
    public async Task<InitialisationResult> Initialise([FromForm]InitialiseCommand request,
        CancellationToken cancellationToken)
    {
        return Mapper!.Map<InitialisationResult>(
            await Mediator!.Send(request, cancellationToken));
    }
}
