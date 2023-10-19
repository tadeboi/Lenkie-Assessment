using Lenkie_Assessment.Infrastructure;
using Lenkie_Assessment.Repositories;
using Lenkie_Assessment.Repositories.Interfaces;
using Lenkie_Assessment.Services;
using Lenkie_Assessment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryAPIConnectionString")));

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = "Cookies";
//    options.DefaultChallengeScheme = "oidc";
//})
//    .AddCookie("Cookies")
//    .AddOpenIdConnect("oidc", options =>
//    {
//        options.Authority = "{IdentityServerURL}";

//        options.ClientId = "{ClientId}";
//        options.ClientSecret = "{ClientSecret}";

//        options.ResponseType = "code";

//        options.SaveTokens = true;
//    });

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

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
