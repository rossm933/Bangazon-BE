
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;
using Bangazon_BE.DTOs;
using System.Runtime.CompilerServices;

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
            // PRODUCTS
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

            // USERS
            // Get all users
            app.MapGet("/users", (BangazonDbContext db) =>
            {
                return db.Users.ToList();
            });

            // Get user by id
            app.MapGet("/users/{UserId}", (BangazonDbContext db, int id) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.UserId == id);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });

            // ORDERS 
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

            // Delete Order
            app.MapDelete("/orders/{id}", (BangazonDbContext db, int id) =>
            {
                var order = db.Orders.SingleOrDefault(order => order.OrderId == id);

                if (order == null)
                {
                    return Results.NotFound();
                }

                db.Orders.Remove(order);
                db.SaveChanges();
                return Results.NoContent();
            });
            // Delete product from oder

            app.MapDelete("/orders/{orderId}/products/{productId}", (BangazonDbContext db, int orderId, int productId) =>
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);
                var product = db.Products.Find(productId);

                if (order == null || product == null)
                {
                    return Results.NotFound("Invalid data request");
                }

                order.Products.Remove(product);
                db.SaveChanges();
                return Results.NoContent();
            });
            // Add product to order
            app.MapPost("/orders/add", (BangazonDbContext db, CartDTO newItem) =>
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == newItem.OrderId);
                var productToAdd = db.Products.Find(newItem.ProductId);

                if (order == null || productToAdd == null)
                {
                    return Results.NotFound();
                }

                try
                {
                    order.Products.Add(productToAdd);
                    db.SaveChanges();
                    return Results.Created($"/api/orders/{newItem.OrderId}/products/{newItem.ProductId}", productToAdd);
                }
                catch
                {
                    return Results.BadRequest("There was an error with the data submitted");
                }
            });
            // Update order
            app.MapPut("/orders/{id}", (BangazonDbContext db, int id, Order order) =>
            {
                Order orderToUpdate = db.Orders.SingleOrDefault(order => order.OrderId == id);
                if (orderToUpdate == null)
                {
                    return Results.NotFound();
                }
                orderToUpdate.Products = order.Products;
                orderToUpdate.Status = order.Status;
                orderToUpdate.PaymentType = order.PaymentType;


                db.SaveChanges();
                return Results.NoContent();
            });
            // ORDERITEM


            app.Run();
        }
    }
}
