using FluentValidation;
using FluentValidation.AspNetCore;
using FoodManager.Core.Mediator.Handler;
using Microsoft.Extensions.DependencyInjection;
using RestaurantsFoods.Application.Commands;
using RestaurantsFoods.Application.Commands.Handlers;
using RestaurantsFoods.Application.Commands.Validators;
using RestaurantsFoods.Application.Queries.CategoryQuery.Handlers;
using RestaurantsFoods.Domain.Entities;
using System.Reflection;

namespace RestaurantsFoods.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<CreateCategoryCommand, Category>();
            });

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCategoryHandler).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCCategoryHandler).GetTypeInfo().Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CategoryValidation>();


            return services;
        }
    }
}
