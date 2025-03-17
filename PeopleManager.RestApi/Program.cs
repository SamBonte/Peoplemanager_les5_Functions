using Microsoft.EntityFrameworkCore;
using PeopleManager.Repository;
using PeopleManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//var connectionString = builder.Configuration.GetConnectionString(nameof(PeopleManagerDbContext));

builder.Services.AddDbContext<PeopleManagerDbContext>(options =>
{
    //options.UseSqlServer(connectionString);
    options.UseInMemoryDatabase(nameof(PeopleManagerDbContext));
});

//Register Services
builder.Services.AddScoped<FunctionService>();
builder.Services.AddScoped<PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<PeopleManagerDbContext>();
    dbContext.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
