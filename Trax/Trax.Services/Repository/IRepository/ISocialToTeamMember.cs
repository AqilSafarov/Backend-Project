using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface ISocialToTeamMember
    {
        List<Models.SocialToTeamMember> GetSocialToTeamMember();
        Models.SocialToTeamMember GetSocialToTeamMember(int id);
        Models.SocialToTeamMember CreateSocialToTeamMember(Models.SocialToTeamMember model);
        Models.SocialToTeamMember UpdateSocialToTeamMember(Models.SocialToTeamMember model);
        bool DeleteSocialToTeamMember(int id);
        List<Models.SocialToTeamMember> OldMember(Models.TeamMember model);
        void Remover(List<Models.SocialToTeamMember> model);

    }
}
