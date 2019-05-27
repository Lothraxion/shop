using Shop.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Interfaces
{
    public interface IAutheticationRepository:IDisposable
    {
        AuthenticationRepository AuthRepository { get; }
        void CommitChanges();
    }
}
