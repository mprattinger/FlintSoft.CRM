using ErrorOr;
using FlintSoft.CRM.Application.Common.Interfaces.Persistence;
using FlintSoft.CRM.Domain.Entities;
using MediatR;
using FlintSoft.CRM.Domain.Common.Errors;

namespace FlintSoft.CRM.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<RegistrationResult>>
{
    public async Task<ErrorOr<RegistrationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        //Check if user already exists
        if (userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create user (generate guid)
        var user = new User
        {
            FirstName = command.FirstName,
            Email = command.Email,
            LastName = command.LastName,
            Password = command.Password
        };

        userRepository.Add(user);

        return new RegistrationResult(
            user
        );
    }
}
