using BestbitePizza.DataServices;
using BestbitePizza.DataServices.Dapper;
using BestbitePizza.DataServices.Dapper.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service registration
builder.Services.AddSingleton<IDataContext, DataContext>();
builder.Services.AddScoped<IPizzaItemDataService, PizzaItemDataService>();

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
