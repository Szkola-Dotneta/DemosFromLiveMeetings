using MinimalApiDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TestApi>();

var app = builder.Build();
//
// app.MapGet("/demo/{demoId:int}/test", async (int demoId) => Results.Ok(new List<int> { 1, 2, 3, 4, 5 }))
//     .Produces<IEnumerable<int>>(StatusCodes.Status200OK)
//     .Produces(StatusCodes.Status404NotFound)
//     .Produces(StatusCodes.Status401Unauthorized);

app.ConfigureDemoModule();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();