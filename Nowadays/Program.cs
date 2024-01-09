using ExampleApi.Extension;
using Nowadays.DAL.Context;
using Nowadays.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


 


ConfigurationManager configuration = builder.Configuration; 
IWebHostEnvironment environment = builder.Environment;
builder.Services.AddDbContextDI(configuration);
builder.Services.AddServicesDI();
builder.Services.AddTransient<AppDbContext>();//Asenkron servis sorununu çözmek için ekledim




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
