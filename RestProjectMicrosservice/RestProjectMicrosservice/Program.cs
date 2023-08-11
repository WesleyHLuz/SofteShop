using RestProjectMicrosservice.Service;
using RestProjectMicrosservice.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Dependendy Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();