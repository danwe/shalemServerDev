using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using shalemServer.Helper;
using shalemServer.Helper.Mapper;
using shalemServer.Interfaces;
using shalemServer.Models;
using shalemServer.Repository;
using shalemServer.Services;
using shalemServer.Services.Interfaces;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("JwtSetting:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("JwtSetting:Key").Get<string>();
var jwtAudience = builder.Configuration.GetSection("JwtSetting:Audiece").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = jwtIssuer,
         ValidAudience = jwtIssuer,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
     };
 });
//Jwt configuration ends here



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Define the Swagger document
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Define the security scheme (bearer token)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    // Add the security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});
builder.Services.AddDbContext<ShalemDbDevContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ShalemDbDevContext>();
builder.Services.AddScoped<IloginRepository, LoginRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserServices, UsersServicve> ();
builder.Services.AddScoped<ClaimService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Strict;

});

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MappingProfile)); // Register AutoMapper with MappingProfile
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
    policy.WithOrigins("http://localhost:4200") // Replace with your Angular app's URL
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials();
    });
});

// Register the repository
builder.Services.AddScoped<IManaRepository>(provider =>
    new ManaRepository(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseTokenValidationMiddleware();
app.UseHttpsRedirection();
//app.UseCors(
//       options => options.WithOrigins("*").AllowAnyMethod()
//   );


app.UseCors("AllowAngular");
app.UseSession(); // Make sure this is added

app.UseAuthorization();

app.MapControllers();

app.Run();
