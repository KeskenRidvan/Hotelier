using Hotelier.EntityLayer.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Hotelier.DataAccessLayer.Contexts;
public class BaseDbContext : DbContext
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
}
