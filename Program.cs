using System.Text;
using FluentValidation;
using MetroClaim.Api.Data;
using MetroClaim.Api.Repositories;
using MetroClaim.Api.Repositrories.Data;
using MetroClaim.Api.Repositrories.Interfaces;
using MetroClaim.Api.Services;
using MetroClaim.Api.Services.Interfaces;
using MetroClaim.Api.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MetroClaimDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApprovalLogRepository, ApprovalLogRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IDisbursementRepository, DisbursementRepository>();
builder.Services.AddScoped<IReimbursementRepository, ReimbursementRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReimbursementService, ReimbursementService>();
builder.Services.AddScoped<IApprovalService, ApprovalService>();
builder.Services.AddScoped<IFinanceService, FinanceService>();

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation()
    .AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddScoped<IHashHandler, HashHandler>();

var smtpServer = builder.Configuration["EmailSettings:SMTPServer"];
var smptpPort = builder.Configuration["EmailSettings:SMTPPort"];
var smtpUsername = builder.Configuration["EmailSettings:MailUsername"];
var smtpPassword = builder.Configuration["EmailSettings:MailPassword"];
var smtpFromMail = builder.Configuration["EmailSettings:MailFrom"];
builder.Services.AddTransient<IEmailHandler, EmailHandler>(_ => new EmailHandler(
    smtpServer ?? "localhost",
    Convert.ToInt16(smptpPort),
    smtpUsername ?? "unknown",
    smtpPassword ?? "unknown",
    smtpFromMail ?? "unknown@mail.id"
));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddHttpContextAccessor();

var jwtKey = builder.Configuration["Jwt:Key"] ?? "InvalidKey";
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "InvalidIssuer";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "InvalidAudience";
var expireTime = Convert.ToInt16(builder.Configuration["Jwt:DurationInMinute"] ?? "1");
builder.Services.AddScoped<ITokenHandler, MetroClaim.Api.Utilities.TokenHandler>(_ => 
    new MetroClaim.Api.Utilities.TokenHandler(jwtKey, jwtIssuer, jwtAudience, expireTime));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(cfg => cfg.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
