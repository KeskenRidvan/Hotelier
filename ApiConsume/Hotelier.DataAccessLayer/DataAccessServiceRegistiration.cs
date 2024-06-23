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

        services.AddScoped<IAboutDal, AboutDal>();
        services.AddScoped<IAppUserDal, AppUserDal>();
        services.AddScoped<IBookingDal, BookingDal>();
        services.AddScoped<IContactDal, ContactDal>();
        services.AddScoped<IGuestDal, GuestDal>();
        services.AddScoped<IMessageCategoryDal, MessageCategoryDal>();
        services.AddScoped<IRoomDal, RoomDal>();
        services.AddScoped<ISendMessageDal, SendMessageDal>();
        services.AddScoped<IServiceDal, ServiceDal>();
        services.AddScoped<IStaffDal, StaffDal>();
        services.AddScoped<ISubscribeDal, SubscribeDal>();
        services.AddScoped<ITestimonialDal, TestimonialDal>();
        services.AddScoped<IWorkLocationDal, WorkLocationDal>();

        return services;
    }
}