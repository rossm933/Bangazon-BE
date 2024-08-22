
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

namespace Bangazon_BE
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // allows passing datetimes without time zone data 
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // allows our api endpoints to access the database through Entity Framework Core
            builder.Services.AddNpgsql<BangazonDbContext>(builder.Configuration["BangazonDbConnectionString"]);

            // Set the JSON serializer options
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            // Add services to the container.
            builder.Services.AddAuthorization();

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



            app.Run();
        }
    }
}
