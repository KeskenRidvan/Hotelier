using AutoMapper;
using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.DtoLayer.Staffs;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class StaffManager : IStaffService
{
	private readonly IStaffDal _staffDal;
	private readonly IMapper _mapper;

	public StaffManager(
		IStaffDal staffDal,
		IMapper mapper)
	{
		_staffDal = staffDal;
		_mapper = mapper;
	}

	public void Delete(int staffId)
	{
		var deletedStaff = _staffDal.GetById(staffId);
		_staffDal.Delete(deletedStaff);
	}

	public StaffGetDto GetById(int staffId)
	{
		Staff staff =
			_staffDal.GetById(staffId);

		StaffGetDto response =
			_mapper.Map<StaffGetDto>(staff);
		return response;
	}

	public List<StaffGetDto> GetList()
	{
		List<Staff> staffs =
			_staffDal.GetList();

		List<StaffGetDto> response =
			_mapper.Map<List<StaffGetDto>>(staffs);
		return response;
	}

	public void Insert(StaffAddDto staffAddDto)
	{
		Staff staff =
			_mapper.Map<Staff>(staffAddDto);
		_staffDal.Insert(staff);
	}

	public void Update(StaffUpdateDto staffUpdateDto)
	{
		Staff staff =
		   _mapper.Map<Staff>(staffUpdateDto);

		_staffDal.Update(staff);
	}
}