using Microsoft.EntityFrameworkCore;
using UserBusiness.IoC;
using UserRepository.DBContext;
using UserRepository.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UsersDBContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(devCorsPolicy, builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

DIServices.AddServices(builder.Services);
DIRepositories.AddRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(devCorsPolicy);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
