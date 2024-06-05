using ApiUsers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<UserDBContex>(options =>
//options.UseInMemoryDatabase("UserDB"));

//builder.Services.AddDbContext<UserDBContex>(options =>
//options.UseSqlite("DataSource=:memory:"));    

builder.Services.AddDbContext<UserDBContex>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CadenaSQL"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
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


app.UseAuthorization();

app.MapControllers();

app.Run();
