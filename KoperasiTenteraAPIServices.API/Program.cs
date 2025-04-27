using KoperasiTenteraAPIServices.API.Extensions;
using KoperasiTenteraAPIServices.Infrastructure.Extensions;
using KoperasiTenteraAPIServices.Shared.HelperModels;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

// Add services to the container.

builder.Host.UseSerilog(logger);

builder.Services.AddControllers();

builder.Services.RegisterAppServices();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Configuration.GetSection("Smtp").Bind(new SmtpConfigModel());

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
