using Hotelier.BusinessLayer.Abstracts;
using Hotelier.BusinessLayer.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace Hotelier.BusinessLayer;
public static class BusinessServiceRegistiration
{
	public static IServiceCollection AddBusinessServices(
		this IServiceCollection services)
	{
		services.AddScoped<IRoomService, RoomManager>();
		services.AddScoped<IServiceService, ServiceManager>();
		services.AddScoped<IStaffService, StaffManager>();
		services.AddScoped<ISubscribeService, SubscribeManager>();
		services.AddScoped<ITestimonialService, TestimonialManager>();

		return services;
	}
}
