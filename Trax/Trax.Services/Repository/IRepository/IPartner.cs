using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface IPartner
    {
        List<Models.Partner> GetPartner();
        Models.Partner GetPartner(int id);
        Models.Partner CreatePartner(Models.Partner model);
        Models.Partner UpdatePartner(Models.Partner model);
        bool DeletePartner(int id);
        Models.Partner FindPartner(int? partnerId);

    }
}
