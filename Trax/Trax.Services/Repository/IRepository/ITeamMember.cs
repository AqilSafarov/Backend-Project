using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface ITeamMember
    {
        List<Models.TeamMember> GetTeamMember();
        Models.TeamMember GetTeamMember(int? id);
        Models.TeamMember CreateTeamMember(Models.TeamMember model);
        Models.TeamMember UpdateTeamMember(Models.TeamMember model);
        bool DeleteTeamMember(int id);
        Models.TeamMember Save(Models.TeamMember model);

    }
}
