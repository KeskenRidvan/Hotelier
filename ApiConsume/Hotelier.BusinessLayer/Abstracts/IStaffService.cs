using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IStaffService
{
	void Insert(Staff staff);
	void Delete(Staff staff);
	void Update(Staff staff);
	List<Staff> GetList();
	Staff GetById(int staffId);
}
