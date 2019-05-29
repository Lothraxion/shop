using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        void AddRoleToUser(string RoleName, string UserName);
        void DeleteRole(string RoleName);
        void RemoveRoleFromUser(string UserName, string RoleName);
        IEnumerable<string> GetRoles(string UserName);

    }
}
