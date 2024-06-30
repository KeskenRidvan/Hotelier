using FluentValidation;
using FluentValidation.AspNetCore;
using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DtoLayer.Abouts;
using Hotelier.DtoLayer.AppUsers;
using Hotelier.DtoLayer.Bookings;
using Hotelier.DtoLayer.Contacts;
using Hotelier.DtoLayer.Guests;
using Hotelier.DtoLayer.Rooms;
using Hotelier.DtoLayer.Services;
using Hotelier.DtoLayer.Staffs;
using Hotelier.DtoLayer.Subscribes;
using Hotelier.DtoLayer.Testimonials;
using Hotelier.EntityLayer.Concretes;
using Hotelier.WebUI_Asp.ValidationRules.Abouts;
using Hotelier.WebUI_Asp.ValidationRules.AppUsers;
using Hotelier.WebUI_Asp.ValidationRules.Bookings;
using Hotelier.WebUI_Asp.ValidationRules.Contacts;
using Hotelier.WebUI_Asp.ValidationRules.Guests;
using Hotelier.WebUI_Asp.ValidationRules.Rooms;
using Hotelier.WebUI_Asp.ValidationRules.Services;
using Hotelier.WebUI_Asp.ValidationRules.Staffs;
using Hotelier.WebUI_Asp.ValidationRules.Subscribes;
using Hotelier.WebUI_Asp.ValidationRules.Testimonials;

namespace Hotelier.WebUI_Asp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddHttpClient();

        builder.Services.AddTransient<IValidator<AboutUpdateDto>, AboutUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
        builder.Services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<LoginDto>, LoginDtoValidator>();
        builder.Services.AddTransient<IValidator<RegisterDto>, RegisterDtoValidator>();

        builder.Services.AddTransient<IValidator<BookingAddDto>, BookingAddDtoValidator>();

        builder.Services.AddTransient<IValidator<GuestAddDto>, GuestAddDtoValidator>();
        builder.Services.AddTransient<IValidator<GuestUpdateDto>, GuestUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<RoomAddDto>, RoomAddDtoValidator>();
        builder.Services.AddTransient<IValidator<RoomUpdateDto>, RoomUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<ContactAddDto>, ContactAddDtoValidator>();

        builder.Services.AddTransient<IValidator<ServiceAddDto>, ServiceAddDtoValidator>();
        builder.Services.AddTransient<IValidator<ServiceUpdateDto>, ServiceUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<StaffAddDto>, StaffAddDtoValidator>();
        builder.Services.AddTransient<IValidator<StaffUpdateDto>, StaffUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<SubscribeAddDto>, SubscribeAddDtoValidator>();
        builder.Services.AddTransient<IValidator<SubscribeUpdateDto>, SubscribeUpdateDtoValidator>();

        builder.Services.AddTransient<IValidator<TestimonialAddDto>, TestimonialAddDtoValidator>();
        builder.Services.AddTransient<IValidator<TestimonialUpdateDto>, TestimonialUpdateDtoValidator>();

        builder.Services.AddControllersWithViews().AddFluentValidation();

        builder.Services.AddDbContext<BaseDbContext>();
        builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BaseDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
