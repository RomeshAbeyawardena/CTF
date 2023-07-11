using CTF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RST.Contracts;

namespace CTF.Features.Authentication;

public class ValidateSessionHandler : IRequestHandler<ValidateSessionQuery, ValidationSessionResponse>
{
    private readonly IMediator mediator;
    private readonly IClockProvider clockProvider;
    private readonly IApplicationSettings applicationSettings;

    public ValidateSessionHandler(IMediator mediator, IClockProvider clockProvider,
        IApplicationSettings applicationSettings)
    {
        this.mediator = mediator;
        this.clockProvider = clockProvider;
        this.applicationSettings = applicationSettings;
    }

    public async Task<ValidationSessionResponse> Handle(ValidateSessionQuery request, CancellationToken cancellationToken)
    {
        //get session
        var sessions = await mediator.Send(new Session.Get(), cancellationToken);
        var session = await sessions.FirstOrDefaultAsync(cancellationToken);
        if(session != null 
            && !string.IsNullOrWhiteSpace(request.SessionKey) 
            && request.SessionKey == session.Key
            && request.SessionToken == session.Token)
        {
            var utcNow = clockProvider.UtcNow;
            var sessionAuthenticationTokens = await mediator!.Send(new SessionAuthenticationToken.GetQuery { 
                SessionId = session.Id,
                StartDate = utcNow.Date
            }, cancellationToken);

            var sessionToken = await sessionAuthenticationTokens.FirstOrDefaultAsync(cancellationToken);

            if (sessionToken != null)
            {
                sessionToken = await mediator.Send(new SessionAuthenticationToken.SaveCommand {
                    SessionId = session.Id,
                    CommitChanges = true,
                    ValidTo = utcNow.Date.AddDays(
                    applicationSettings
                        .SessionAuthenticationTokenValidityPeriodInDays)
                }, cancellationToken);
            }

            return new ValidationSessionResponse
            {
                Success = sessionToken != null,
                AuthenticationToken = sessionToken?.Value,// generate token
                TokenExpiry = sessionToken?.ValidTo
            };
        }

        return new ValidationSessionResponse { Success = false };
    }
}
