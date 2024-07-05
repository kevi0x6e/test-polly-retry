using System.Net;
using application.GetStatusCodeService;
using domain.Application;
using domain.Infrastructure;
using infrastructure;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Polly Retry API Testing", Version = "v1" });
});

var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
    .WaitAndRetryAsync(3, retryAttempt => 
        {
            var waitTime = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
            Console.WriteLine($"Retry attempt {retryAttempt} - Waiting {waitTime}");
            return waitTime;
        });

builder.Services.AddHttpClient("LocalPollyRetryTest")
    .AddPolicyHandler(retryPolicy);

builder.Services.AddScoped<ILocalExternalService, LocalExternalService>();
builder.Services.AddScoped<IGetStatusCodeService, GetStatusCodeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Polly Retry API Testing");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
