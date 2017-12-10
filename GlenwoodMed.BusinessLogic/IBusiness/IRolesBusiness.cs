using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic
{
    public interface IRolesBusiness
    {

        void RoleCreate(string roleName);
        List<string> RoleIndex();
        void RoleDelete(string roleName);
        void AddRoleToUser(string Id, string userName, string error);
        void RoleAddToUser(string roleName, string userName,string error);
        List<string> GetgRoles(string username);
        List<IdentityRole> identityRole();
        List<string> GetallUsers(List<string> users);
        List<string> GetallRoles(List<string> roles);
        List<IdentityRole> GetMyRoles();
        List<string> GetUserRoles(string username);
        void DeleteRoleForUser(string userName, string roleName);
    }
}
