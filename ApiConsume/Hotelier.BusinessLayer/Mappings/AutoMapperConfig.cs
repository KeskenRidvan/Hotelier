using AutoMapper;
using Hotelier.DtoLayer.Rooms;
using Hotelier.DtoLayer.Staffs;
using Hotelier.DtoLayer.Testimonials;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Mappings;
public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		CreateMap<StaffGetDto, Staff>().ReverseMap();
		CreateMap<StaffAddDto, Staff>().ReverseMap();
		CreateMap<StaffUpdateDto, Staff>().ReverseMap();

		CreateMap<TestimonialGetDto, Testimonial>().ReverseMap();
		CreateMap<TestimonialAddDto, Testimonial>().ReverseMap();
		CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();

		CreateMap<RoomGetDto, Room>().ReverseMap();
		CreateMap<RoomAddDto, Room>().ReverseMap();
		CreateMap<RoomUpdateDto, Room>().ReverseMap();
	}
}
