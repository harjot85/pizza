using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Context;
using BestbitePizza.DataServices.Dapper.Context;
using BestbitePizza.DataServices.Dapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service registration
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<ICosmosRepository, CosmosRepository>();
builder.Services.AddScoped<IMenuItemDataService, MenuItemDataService>();
//builder.Services.AddScoped<IMenuItemDataService, BestbitePizza.DataServices.Cosmos.Services.MenuItemDataService>();


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
