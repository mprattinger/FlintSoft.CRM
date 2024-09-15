using FlintSoft.CRM.Application.Authentication.Commands.Register;
using FlintSoft.CRM.Application.Authentication.Queries.Login;
using FlintSoft.CRM.Contracts.Authentication;
using Mapster;

namespace FlintSoft.CRM.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<RegistrationResult, RegisterResponse>()
            .Map(dest => dest, src => src.user);

        config.NewConfig<LoginResult, LoginResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.user);
    }
}
