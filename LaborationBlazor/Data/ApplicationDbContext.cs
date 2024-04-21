using LaborationBlazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LaborationBlazor.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Cart> Carts { get; set; } 
    public DbSet<CartProduct> CartProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Pet Eagle (Apollo)",
                Description = "A two year old tame eagle",
                Price = 499.99M,
                ImgUrl = "https://images.pexels.com/photos/16658578/pexels-photo-16658578/free-photo-of-flyg-fagel-djur-orn.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                Quantity = 1,
                IsOnSale = true
            },
            new Product
            {
                Id = 2,
                Name = "Fender Startocaster",
                Description = "Surprisingly well sounding beginner guitar",
                Price = 1999.99M,
                ImgUrl = "https://images.pexels.com/photos/1545333/pexels-photo-1545333.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                Quantity = 10
            },
            new Product
            {
                Id = 3,
                Name = "Mini Cooper Car",
                Description = "A real fully functional car, not a model",
                Price = 19999.99M,
                ImgUrl = "https://images.pexels.com/photos/35967/mini-cooper-auto-model-vehicle.jpg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                Quantity = 5
            },
            new Product
            {
                Id = 4,
                Name = "Suit set XXL",
                Description = "A luxurious kit from Dressman XL, for the man on the larger side",
                Price = 999.99M,
                ImgUrl = "https://images.pexels.com/photos/2709563/pexels-photo-2709563.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                Quantity = 15
            },
            new Product
            {
                Id = 5,
                Name = "Finland",
                Description = "The beautiful country called Finland, no further explaination is needed",
                Price = 19999999999999.99M,
                ImgUrl = "https://images.pexels.com/photos/2311602/pexels-photo-2311602.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                Quantity = 0
            });


    }
}
