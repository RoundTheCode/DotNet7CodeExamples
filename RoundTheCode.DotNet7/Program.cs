using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using RoundTheCode.DotNet7.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "TestPolicy", options =>
    {
        options.PermitLimit = 1;
        options.Window = TimeSpan.FromSeconds(12);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 3;
    }));

var app = builder.Build();

app.UseRateLimiter();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/minimal-api", (int count) =>
{
    return count;
})
.WithOpenApi(op =>
{
    op.Parameters[0].Description = "Represents the count";
    return op;
});

app.MapPost("/upload-file", async (IFormFile file) =>
{
    var fileName = "MyFile.jpg";

    using var stream = File.OpenWrite(fileName);
    await file.CopyToAsync(stream);

    return fileName;
});

app.Run();
