using Hotelier.BusinessLayer.Abstracts;
using Hotelier.BusinessLayer.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Hotelier.BusinessLayer;
public static class BusinessServiceRegistiration
{
    public static IServiceCollection AddBusinessServices(
        this IServiceCollection services)
    {

        services.AddScoped<IAboutService, AboutManager>();
        services.AddScoped<IAppUserService, AppUserManager>();
        services.AddScoped<IBookingService, BookingManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IGuestService, GuestManager>();
        services.AddScoped<IMessageCategoryService, MessageCategoryManager>();
        services.AddScoped<IRoomService, RoomManager>();
        services.AddScoped<ISendMessageService, SendMessageManager>();
        services.AddScoped<IServiceService, ServiceManager>();
        services.AddScoped<IStaffService, StaffManager>();
        services.AddScoped<ISubscribeService, SubscribeManager>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<IWorkLocationService, WorkLocationManager>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
