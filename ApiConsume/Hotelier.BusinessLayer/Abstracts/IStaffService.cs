using Hotelier.DtoLayer.Staffs;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IStaffService
{
	void Insert(StaffAddDto staffAddDto);
	void Delete(int staffId);
	void Update(StaffUpdateDto staffUpdateDto);
	List<StaffGetDto> GetList();
	StaffGetDto GetById(int staffId);
}