using AutoMapper;
using Hotelier.DtoLayer.Abouts;
using Hotelier.DtoLayer.AppUsers;
using Hotelier.DtoLayer.Bookings;
using Hotelier.DtoLayer.Contacts;
using Hotelier.DtoLayer.Guests;
using Hotelier.DtoLayer.MessageCategories;
using Hotelier.DtoLayer.Rooms;
using Hotelier.DtoLayer.SendMessages;
using Hotelier.DtoLayer.Services;
using Hotelier.DtoLayer.Staffs;
using Hotelier.DtoLayer.Subscribes;
using Hotelier.DtoLayer.Testimonials;
using Hotelier.DtoLayer.WorkLocations;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Mappings;
public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<AboutGetDto, About>().ReverseMap();
        CreateMap<AboutAddDto, About>().ReverseMap();
        CreateMap<AboutUpdateDto, About>().ReverseMap();

        CreateMap<AppUserGetDto, AppUser>().ReverseMap();
        CreateMap<AppUserAddDto, AppUser>().ReverseMap();
        CreateMap<AppUserUpdateDto, AppUser>().ReverseMap();
        CreateMap<RegisterDto, AppUser>().ReverseMap();
        CreateMap<LoginDto, AppUser>().ReverseMap();

        CreateMap<BookingGetDto, Booking>().ReverseMap();
        CreateMap<BookingAddDto, Booking>().ReverseMap();
        CreateMap<BookingUpdateDto, Booking>().ReverseMap();

        CreateMap<ContactGetDto, Contact>().ReverseMap();
        CreateMap<ContactAddDto, Contact>().ReverseMap();
        CreateMap<ContactUpdateDto, Contact>().ReverseMap();

        CreateMap<GuestGetDto, Guest>().ReverseMap();
        CreateMap<GuestAddDto, Guest>().ReverseMap();
        CreateMap<GuestUpdateDto, Guest>().ReverseMap();

        CreateMap<MessageCategoryGetDto, MessageCategory>().ReverseMap();
        CreateMap<MessageCategoryAddDto, MessageCategory>().ReverseMap();
        CreateMap<MessageCategoryUpdateDto, MessageCategory>().ReverseMap();

        CreateMap<RoomGetDto, Room>().ReverseMap();
        CreateMap<RoomAddDto, Room>().ReverseMap();
        CreateMap<RoomUpdateDto, Room>().ReverseMap();

        CreateMap<SendMessageGetDto, SendMessage>().ReverseMap();
        CreateMap<SendMessageAddDto, SendMessage>().ReverseMap();
        CreateMap<SendMessageUpdateDto, SendMessage>().ReverseMap();

        CreateMap<ServiceGetDto, Service>().ReverseMap();
        CreateMap<ServiceAddDto, Service>().ReverseMap();
        CreateMap<ServiceUpdateDto, Service>().ReverseMap();

        CreateMap<StaffGetDto, Staff>().ReverseMap();
        CreateMap<StaffAddDto, Staff>().ReverseMap();
        CreateMap<StaffUpdateDto, Staff>().ReverseMap();

        CreateMap<SubscribeGetDto, Subscribe>().ReverseMap();
        CreateMap<SubscribeAddDto, Subscribe>().ReverseMap();
        CreateMap<SubscribeUpdateDto, Subscribe>().ReverseMap();

        CreateMap<TestimonialGetDto, Testimonial>().ReverseMap();
        CreateMap<TestimonialAddDto, Testimonial>().ReverseMap();
        CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();

        CreateMap<WorkLocationGetDto, WorkLocation>().ReverseMap();
        CreateMap<WorkLocationAddDto, WorkLocation>().ReverseMap();
        CreateMap<WorkLocationUpdateDto, WorkLocation>().ReverseMap();
    }
}