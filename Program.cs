
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;

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

            // Get all products
            app.MapGet("/products", (BangazonDbContext db) =>
            {
                var orderedProducts = db.Products.OrderByDescending(c => c.DateAdded).ToList();
                return Results.Ok(orderedProducts);
            });

            // Get a product by id
            app.MapGet("/products/{id}", (BangazonDbContext db, int id) =>
            {
                Product selectedProduct = db.Products.FirstOrDefault(p => p.ProductId == id);
                if (selectedProduct == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedProduct);
            });

            // Get all users
            app.MapGet("/users", (BangazonDbContext db) =>
            {
                return db.Users.ToList();
            });

            // Get user by id
            app.MapGet("/users/{id}", (BangazonDbContext db, int id) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.UserId == id);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });

            // Get all orders   
            app.MapGet("/orders", (BangazonDbContext db) =>
            {
                return db.Orders.ToList();
            });

            // Get order by UserId
            app.MapGet("/user/{UserId}/orders", (BangazonDbContext db, int UserId) =>
            {
                var order = db.Orders.Where(order => order.UserId == UserId && order.Status).ToList();
                return order;
            });



            app.Run();
        }
    }
}
