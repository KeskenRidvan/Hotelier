using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hotelier.DataAccessLayer;
public static class DataAccessServiceRegistiration
{
	public static IServiceCollection AddDataAccessServices(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<BaseDbContext>();

		services.AddScoped<IRoomDal, RoomDal>();
		services.AddScoped<IServiceDal, ServiceDal>();
		services.AddScoped<IStaffDal, StaffDal>();
		services.AddScoped<ISubscribeDal, SubscribeDal>();
		services.AddScoped<ITestimonialDal, TestimonialDal>();

		return services;
	}
}