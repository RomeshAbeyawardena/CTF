using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CTF.Features.Authentication;

public class ValidateSessionHandler : IRequestHandler<ValidateSessionQuery, ValidationSessionResponse>
{
    private readonly IMediator mediator;

    public ValidateSessionHandler(IMediator mediator)
    {
        this.mediator = mediator;
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
            return new ValidationSessionResponse
            {
                Success = true,
                AuthenticationToken = ""// generate token,
                ,
                TokenExpiry = DateTime.UtcNow.AddHours(1)
            };
        }

        return new ValidationSessionResponse { Success = false };
    }
}
