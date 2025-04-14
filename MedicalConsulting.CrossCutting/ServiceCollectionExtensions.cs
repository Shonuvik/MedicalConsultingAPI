using MedicalConsulting.Application.Handlers;
using MedicalConsulting.Application.Interfaces;
using MedicalConsulting.Domain.Interfaces;
using MedicalConsulting.Infrastructure.DbContext;
using MedicalConsulting.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalConsulting.CrossCutting;

public static class ServiceCollectionExtensions
{
    public static void AddIoC(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IManagementScheduleHandler, ManagementScheduleHandler>();

        services.AddScoped<IManagementScheduleRepository, ManagementScheduleRepository>();
    }
}

