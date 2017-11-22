using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLevel.Entities
{
    public class Friend
    {
        public int FriendId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
