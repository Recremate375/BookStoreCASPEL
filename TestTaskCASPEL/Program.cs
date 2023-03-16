using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Common;
using TestTaskCASPEL.Data;
using TestTaskCASPEL.Middlewares;
using TestTaskCASPEL.Repository;
using TestTaskCASPEL.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

#region Configure MSSQL

builder.Services.AddDbContext<BookStoreDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region Configure AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion

#region

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

#endregion

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
