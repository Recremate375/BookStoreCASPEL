using Microsoft.EntityFrameworkCore;
using TestTaskCASPEL.Common;
using TestTaskCASPEL.Data;
using TestTaskCASPEL.Middlewares;
using TestTaskCASPEL.Repository;
using TestTaskCASPEL.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configure MSSQL

builder.Services.AddDbContext<BookStoreDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnectionString")));

#endregion

#region Configure AutoMapper

builder.Services.AddAutoMapper(typeof (MappingProfile));

#endregion

#region

builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

#endregion

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
