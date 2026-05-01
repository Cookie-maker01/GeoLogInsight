using GeoLogInsight.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Controller
builder.Services.AddControllers();

//Signal R
builder.Services.AddSignalR();

builder.Services.AddSingleton<GeoService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy
                .WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.MapHub<GeoLogInsight.API.Hubs.LogHub>("/logHub");

app.Run();
