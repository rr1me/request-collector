using Microsoft.EntityFrameworkCore;
using requestCollector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(x => 
	x.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

app.UseCollectorMiddleware();

var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<DatabaseContext>();
db.Database.EnsureCreated();
db.SaveChanges();

app.Run();