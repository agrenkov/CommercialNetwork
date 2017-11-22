using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;
using DatabaseLevel.Repositories;
using DatabaseLevel.Interfaces;

namespace DatabaseLevel.Repositories
{
    public class ClientManager : IClientManager
    {
        public DatabaseContext Database { get; set; }
        public ClientManager(DatabaseContext db)
        {
            Database = db;
        }

        public void Create(User item)
        {
            Database.Users.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
