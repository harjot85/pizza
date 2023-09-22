using BestbitePizza.DataServices.Contracts;
using BestbitePizza.DataServices.Cosmos.Repositories;
using BestbitePizza.DataServices.Dapper.Repositories;
using BestbitePizza.DataServices.Dapper.Services;
using BestbitePizza.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// service registration
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddSingleton<ICosmosBaseRepository, CosmosBaseRepository>();
builder.Services.AddScoped<IMenuItemRepositoryAggregated, MenuItemRepositoryAggregated>();
//builder.Services.AddScoped<IMenuItemDataService, BestbitePizza.DataServices.Cosmos.Services.MenuItemDataService>();
builder.Services.AddTransient<IMenuServiceAggregated, MenuServiceAggregated>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty)),
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
    .WithOrigins("http://localhost:5173")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
