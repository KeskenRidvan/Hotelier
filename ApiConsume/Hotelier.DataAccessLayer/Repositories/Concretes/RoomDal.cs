﻿using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;
public class RoomDal : Repository<Room>, IRoomDal
{
    public RoomDal(BaseDbContext context) : base(context)
    {
    }

    public int RoomCount()
    {
        using (var context = new BaseDbContext())
        {
            return context.Rooms.Count();
        }
    }
}