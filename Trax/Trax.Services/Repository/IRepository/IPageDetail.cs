using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IPageDetail
    {
        Models.PageDetail GetPageDetail();
        Models.PageDetail CreatePageDetail(Models.PageDetail model);
        Models.PageDetail UpdatePageDetail(Models.PageDetail model);
        bool DeletePageDetail(int id);

    }
}
