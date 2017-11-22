using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;

namespace DatabaseLevel.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(User item);
    }
}
