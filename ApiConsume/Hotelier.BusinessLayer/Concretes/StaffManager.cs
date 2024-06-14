using Hotelier.BusinessLayer.Abstracts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Concretes;

public class StaffManager : IStaffService
{
	private readonly IStaffDal _staffDal;

	public StaffManager(IStaffDal staffDal)
	{
		_staffDal = staffDal;
	}

	public void Delete(Staff staff)
	{
		_staffDal.Delete(staff);
	}

	public Staff GetById(int staffId)
	{
		return _staffDal.GetById(staffId);
	}

	public List<Staff> GetList()
	{
		return _staffDal.GetList();
	}

	public void Insert(Staff staff)
	{
		_staffDal.Insert(staff);
	}

	public void Update(Staff staff)
	{
		_staffDal.Update(staff);
	}
}