
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");
            app.UseAuthorization();

            // PRODUCTS
            // Get all products
            app.MapGet("/products", (BangazonDbContext db) =>
            {
                return db.Products.Include(p => p.Category).ToList();

            });

            // Get a product by id
            app.MapGet("/products/{productId}", (BangazonDbContext db, int productId) =>
            {
                var product = db.Products
                                .Include(p => p.Category)
                                .SingleOrDefault(u => u.ProductId == productId);

                if (product == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(product);

            });

            //Get products by category
            app.MapGet("/products/category/{categoryId}", (BangazonDbContext db, int categoryId) =>
            {
                return db.Products.Where(product => product.CategoryId == categoryId).ToList();
            });

            // USERS
            // Get all users
            app.MapGet("/users", (BangazonDbContext db) =>
            {
                return db.Users.ToList();
            });

            // Get user by id
            app.MapGet("/users/{Id}", (BangazonDbContext db, int id) => {
                User selectedUser = db.Users.FirstOrDefault(u => u.Id == id);
                if (selectedUser == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(selectedUser);
            });
            // Check user
            app.MapGet("/checkuser/{uid}", (BangazonDbContext db, string uid) =>
            {
                var authUser = db.Users.Where(u => u.Uid == uid).FirstOrDefault();
                if (authUser == null)
                {
                    return Results.StatusCode(204);
                }
                return Results.Ok(authUser);
            });

            // Register user
            app.MapPost("/users", (BangazonDbContext db, User userInfo) =>
            {
                db.Users.Add(userInfo);
                db.SaveChanges();
                return Results.Created($"/users/{userInfo.Id}", userInfo);
            });
            // Get user by Id
            app.MapGet("/users/details/{uid}", (BangazonDbContext db, string uid) =>
            {

                User user = db.Users.FirstOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(user);
            });
            // Switch user to seller
            app.MapPatch("/users/sell/{uid}", async (BangazonDbContext db, string uid) =>
            {
                User user = db.Users.SingleOrDefault(u => u.Uid == uid);

                if (user == null)
                {
                    return Results.NotFound();
                }

                user.Seller = true;
                await db.SaveChangesAsync();

                return Results.Ok(user);
            });
            // ORDERS 
            // Get all orders   
            app.MapGet("/orders", (BangazonDbContext db) =>
            {
                // Include PaymentType to retrieve related information
                return db.Orders.Include(o => o.PaymentType).ToList();
            });

            app.MapGet("/orders/{id}/products", (BangazonDbContext db, int id) =>
            {
                var Order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == id);
                return Order;
            });


            // get order details (products)
            app.MapGet("/products/{id}/orders", (BangazonDbContext db, int id) =>
            {
                var product = db.Products.Include(p => p.Orders).FirstOrDefault(p => p.ProductId == id);
                return product;
            });


            // Delete Order
            app.MapDelete("/orders/{id}", (BangazonDbContext db, int id) =>
            {
                Order orderToDelete = db.Orders.SingleOrDefault(p => p.OrderId == id);
                if (orderToDelete == null)
                {
                    return Results.NotFound();
                }
                db.Orders.Remove(orderToDelete);
                db.SaveChanges();
                return Results.Ok(db.Orders);
            });
            // Delete product from order
            app.MapDelete("/orders/{orderId}/products/{productId}", (BangazonDbContext db, int orderId, int productId) =>
            {
                var order = db.Orders.Include(o => o.Products).SingleOrDefault(o => o.OrderId == orderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                var removeProduct = order.Products.FirstOrDefault(p => p.ProductId == productId);

                if (removeProduct == null)
                {
                    return Results.NotFound("Product not found.");
                }

                order.Products.Remove(removeProduct);
                db.SaveChanges();
                return Results.Ok("Product removed from order.");
            });

            // Add product to order
            app.MapPost("/orders/addProduct", (BangazonDbContext db, CartDTO newProduct) =>
            {
                var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == newProduct.OrderId);

                if (order == null)
                {
                    return Results.NotFound("Order not found.");
                }

                var product = db.Products.Find(newProduct.ProductId);

                if (product == null)
                {
                    return Results.NotFound("Product not found.");
                }

                var existingProduct = order.Products.FirstOrDefault(p => p.ProductId == newProduct.ProductId);

                if (existingProduct != null)
                {
                    existingProduct.QuantityAvailable += newProduct.QuantityAvailable;
                }
                else
                {
                    product.QuantityAvailable = newProduct.QuantityAvailable;
                    order.Products.Add(product);
                }

                db.SaveChanges();

                return Results.Created($"/orders/addProduct", newProduct);
            });

            // Categories
            // Get all categories
            app.MapGet("/category", (BangazonDbContext db) =>
            {
                return db.Category.ToList();
            });
            // Get category by id
            app.MapGet("/categories/{id}", (BangazonDbContext db, int id) =>
            {
                var category = db.Category.SingleOrDefault(category => category.Id == id);
                return category.Name;
            });
            //Payment
            app.MapGet("/paymentType", (BangazonDbContext db) =>
            {
                return db.PaymentTypes.ToList();
            });

            app.Run();
        }
    }
}
