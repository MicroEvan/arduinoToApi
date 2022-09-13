using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Tracking;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddDbContext<DatabaseContext>(o => {
    o.UseSqlite("Data Source=Locations.db");
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(o =>
{
    o.AllowAnyHeader();
    o.AllowAnyMethod();
    o.AllowAnyOrigin();
});
app.MapPost("/api/location",([FromBody]Location location, DatabaseContext db) =>
{   
    location.TimeStamp = DateTime.Now;
    db.Locations.Add(location);
    return db.SaveChanges();
}); 

app.MapGet("/api/locations",async (DatabaseContext db) =>
{
    return await db.Locations.ToListAsync();
});

app.MapGet("/api/latestlocation",async (DatabaseContext db) =>
{
    return db.Locations.OrderBy(l=>l.TimeStamp).Last();
});

app.Run();

