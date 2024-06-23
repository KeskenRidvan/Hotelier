using Hotelier.EntityLayer.Concretes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotelier.DataAccessLayer.Contexts;
public class BaseDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\UDEMY;initial catalog=Mrt.HotelierDB;integrated security=true");
    }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<Subscribe> Subscribes { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<SendMessage> SendMessages { get; set; }
    public DbSet<MessageCategory> MessageCategories { get; set; }
    public DbSet<WorkLocation> WorkLocations { get; set; }
}