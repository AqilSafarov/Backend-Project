using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public  interface IContact
    {
        Models.Contact GetContact();
        Models.Contact CreateContact(Models.Contact model);
        Models.Contact UpdateContact(Models.Contact model);
        bool DeleteContact(int id);
        Models.Contact FindContact(int? contactId);

        List<Models.Contact> GetContacts();


    }
}
