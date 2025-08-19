using Microsoft.EntityFrameworkCore;
using ApiProjectCamp.WebApi.Entities;

public class PostgreApiContext : DbContext
{
    public PostgreApiContext(DbContextOptions<PostgreApiContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Chef> Chefs { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<About> Abouts { get; set; }
}
