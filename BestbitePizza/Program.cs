using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Repositories;
using BestbitePizza.DataServices.Dapper.Repositories;
using BestbitePizza.DataServices.Dapper.Services;
using BestbitePizza.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service registration
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<ICosmosBaseRepository, CosmosBaseRepository>();
builder.Services.AddScoped<IMenuItemRepositoryAggregated, MenuItemRepositoryAggregated>();
//builder.Services.AddScoped<IMenuItemDataService, BestbitePizza.DataServices.Cosmos.Services.MenuItemDataService>();
builder.Services.AddTransient<IMenuServiceAggregated, MenuServiceAggregated>();


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
