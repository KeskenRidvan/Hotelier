﻿using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Abstracts;

public interface IAppUserDal : IRepository<AppUser>
{
    List<AppUser> UserListWithWorkLocation();
    int AppUserCount();
}
