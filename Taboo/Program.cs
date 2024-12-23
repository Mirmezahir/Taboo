
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.Service.Abstracts;
using Taboo.Service.Implements;

namespace Taboo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<TaboDbContex>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("MSSql")));
            builder.Services.AddScoped<ILAnguageService, LanguageService>();
            builder.Services.AddScoped<IWordService, WordService>();
            builder.Services.AddScoped<IBannedWordService, BannedWordService>();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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
        }
    }
}
