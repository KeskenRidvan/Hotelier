using Microsoft.AspNetCore.Identity;

namespace Hotelier.EntityLayer.Concretes;
public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
}
