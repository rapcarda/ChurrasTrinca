using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TrincaChurrasco.API.Application.Commands.AdicionarParticipante;
using TrincaChurrasco.API.Application.Commands.CriarChurrasco;
using TrincaChurrasco.API.Application.Queries.DetalhesChurrasco;
using TrincaChurrasco.API.Mediatr;
using TrincaChurrasco.Domain.Interfaces;
using TrincaChurrasco.Infra.Data;
using TrincaChurrasco.Infra.Data.Repositories;

namespace TrincaChurrasco.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IChurrascoRepository, ChurrascoRepository>();

            // Queries
            services.AddScoped<IDetalhesChurrascoQueries, DetalhesChurrascoQueries>();

            // Commands
            services.AddScoped<IRequestHandler<CriarChurrascoCommand, ValidationResult>, CriarChurrascoHandler>();
            services.AddScoped<IRequestHandler<AdicionarParticipanteCommand, ValidationResult>, AdicionarParticipanteHandler>();
            
            // Mediatr
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Context
            services.AddScoped<TrincaChurrascoContext>();
        }
    }
}
