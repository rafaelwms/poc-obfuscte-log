using Microsoft.Extensions.Compliance.Redaction;
using ObfuscateLogPoc.Domain.Obfuscate.Redactor;
using ObfuscateLogPoc.Domain.Obfuscate.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
builder.Services.AddScoped<IRedactorProvider, ObfuscateLogRedactorProvider>();
builder.Services.AddRedaction(redactorBuilder => { });
builder.Services.AddScoped<IObfuscationService, ObfuscationService>();
builder.Services.AddScoped<IPayloadLoggerService, PayloadLoggerService>();

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