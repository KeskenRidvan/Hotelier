using Hotelier.DtoLayer.Staffs;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.BusinessLayer.Abstracts;

public interface IStaffService
{
    void Insert(StaffAddDto staffAddDto);
    void Delete(int staffId);
    void Update(StaffUpdateDto staffUpdateDto);
    List<StaffGetDto> GetList();
    StaffGetDto GetById(int staffId);
    int GetStaffCount();
    List<Staff> Last4Staff();
}