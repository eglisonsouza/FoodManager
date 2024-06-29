using GetFood.Application.Services;
using GetFood.Infra;
using GetFood.Infra.Gateways;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfra();
builder.Services.AddScoped<IRestaurantsFoodsGateway, RestaurantsFoodsGateway>();
builder.Services.AddScoped<IPageInitialService, PageInitialService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
