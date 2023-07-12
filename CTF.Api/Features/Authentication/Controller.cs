using AutoMapper;
using CTF.Features.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RST.Contracts;
using RST.DependencyInjection.Extensions.Attributes;

namespace CTF.Api.Features.Authentication;

[ApiController, Route(API_URL)]
public class Controller : RST.DependencyInjection.Extensions.EnableInjectionBase<InjectAttribute>
{
    public const string API_URL = $"{Api.CURRENT_API_BASE_URL}/Authentication";
    [Inject] protected IMapper? Mapper { get; set; }
    [Inject] protected IMediator? Mediator { get; set; }

    public Controller(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.ConfigureInjection();
    }

    [HttpGet, ] public async Task<IPagedResult<Models.ValidationSessionResponse>> Validate(
        [FromHeader] ValidateSessionQuery query, CancellationToken cancellationToken)
    {
        return Mapper!.Map<IPagedResult<Models.ValidationSessionResponse>>(
            await Mediator!.Send(query, cancellationToken));
    }

}
