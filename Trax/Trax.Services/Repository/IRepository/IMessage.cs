using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IMessage
    {
        Models.Message GetMessage();
        Models.Message CreateMessage(Models.Message model);
        Models.Message UpdateMessage(Models.Message model);
        bool DeleteMessage(int id);
        bool GetMessage(string email);

        List<Models.Message> GetMessages();


    }
}
