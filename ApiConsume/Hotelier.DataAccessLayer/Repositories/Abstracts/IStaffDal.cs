using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Abstracts;

public interface IStaffDal : IRepository<Staff>
{
    int GetStaffCount();
    List<Staff> Last4Staff();
}