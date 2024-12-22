using Microsoft.EntityFrameworkCore;
using System.Text;
using VowsAndVeils.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using StayNest_API.Services;
using VowsAndVeils.Interfaces;
using AutoMapper;
using VowsAndVeils.DTOs;
using VowsAndVeils.Data.Models;
using VowsAndVeils.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidAudience = null,
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Auth:Secret"])),
        ValidateIssuerSigningKey = true,
        RequireExpirationTime = false,
        ValidateLifetime = false,
        ClockSkew = TimeSpan.Zero
    };
    options.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add CORS policy
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));


builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWeddingDressService, WeddingDressService>();
builder.Services.AddAutoMapper(typeof(Program));


var mapperConfig = new MapperConfiguration(cfg =>
{
    // Mapiranje za registraciju korisnika
    cfg.CreateMap<RegisterUserRequestDTO, Users>()
        .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorišite polje koje se ne mapira
        .ForMember(dest => dest.Password, opt => opt.Ignore()); // Ignorišite jer se ruèno dodaje hash

    // Mapiranje za odgovor korisnika
    cfg.CreateMap<Users, UserResponseDTO>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS
app.UseCors("MyPolicy");

// Apply Authentication & Authorization
app.UseAuthentication(); // Dodaj autentifikaciju
app.UseAuthorization();

app.MapControllers();

app.Run();
