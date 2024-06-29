using FoodManager.Core.Mediator.Filters;
using RestaurantsFoods.Application;
using RestaurantsFoods.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers
    (
        options =>
        {
            options.Filters.Add(typeof(ValidationFilter));
        }
    ).ConfigureApiBehaviorOptions
    (
        options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        }
    );

builder.Services
    .AddAplication()
    .AddInfrastructure(builder.Configuration)
    .AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
