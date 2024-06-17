﻿using Hotelier.BusinessLayer.Abstracts;
using Hotelier.BusinessLayer.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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


		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		return services;
	}
}
