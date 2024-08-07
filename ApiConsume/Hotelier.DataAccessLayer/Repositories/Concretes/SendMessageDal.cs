﻿using Hotelier.DataAccessLayer.Contexts;
using Hotelier.DataAccessLayer.Repositories.Abstracts;
using Hotelier.EntityLayer.Concretes;

namespace Hotelier.DataAccessLayer.Repositories.Concretes;

public class SendMessageDal : Repository<SendMessage>, ISendMessageDal
{
    public SendMessageDal(BaseDbContext context) : base(context)
    {
    }

    public int GetSendMessageCount()
    {
        using (var context = new BaseDbContext())
        {
            return context.SendMessages.Count();
        }
    }
}