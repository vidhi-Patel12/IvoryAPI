using Braintree;
using Ivory.Data;
using Ivory.Interface;
using Ivory.Models;
using Ivory.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<ILogin, LoginRepository>();
builder.Services.AddScoped<IService, ServiceRepository>();
builder.Services.AddScoped<ISubService, SubServiceRepository>();


builder.Services.AddSingleton<SmsService>();

builder.Services.AddSingleton<IBraintreeGateway>(provider =>
{
    return new BraintreeGateway
    {
        Environment = Braintree.Environment.SANDBOX, // Or .PRODUCTION
        MerchantId = builder.Configuration["Braintree:MerchantId"],
        PublicKey = builder.Configuration["Braintree:PublicKey"],
        PrivateKey = builder.Configuration["Braintree:PrivateKey"]
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5502") // your frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.ValidatorUrl(null);
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ivory v1");
    });
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();   

app.UseAuthorization();

app.MapControllers();

app.Run();
