using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface ISkill
    {
        List<Models.Skill> GetSkill();
        Models.Skill GetSkill(int id);
        Models.Skill CreateSkill(Models.Skill model);
        Models.Skill UpdateSkill(Models.Skill model);
        bool DeleteSkill(int id);
    }
}
