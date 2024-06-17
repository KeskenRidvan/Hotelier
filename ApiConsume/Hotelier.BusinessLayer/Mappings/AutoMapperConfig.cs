using AutoMapper;
using Hotelier.DtoLayer.Staffs;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Mappings;
public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
	{
		CreateMap<StaffGetDto, Staff>().ReverseMap();
		CreateMap<StaffAddDto, Staff>().ReverseMap();
		CreateMap<StaffUpdateDto, Staff>().ReverseMap();
	}
}
