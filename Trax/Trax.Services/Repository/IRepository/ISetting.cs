using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface ISetting
    {
        Models.Setting GetSetting();
        Models.Setting CreateSetting(Models.Setting model);
        Models.Setting UpdateSetting(Models.Setting model);
        bool DeleteSetting(int id);
        bool CheckSetting(Models.Setting model);
        Models.Setting FindSetting(int? settingId);


    }
}
