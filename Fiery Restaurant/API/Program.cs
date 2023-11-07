using Business.Mapping;
using Business.Service.implement;
using Business.Service.Interfaces;
using Data.DataAccessLayer;
using Data.Repository.implement;
using Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
			builder.Services.AddCors((setup) =>
			{
				setup.AddPolicy("default", (Options) =>
				{
					Options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
				});
			});

			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<IProductRepository, ProductRepository>();
			builder.Services.AddScoped<AppDbContext>();
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
		}
	}
}