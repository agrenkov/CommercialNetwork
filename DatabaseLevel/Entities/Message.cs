using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLevel.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int AddresserId { get; set; }
        public int RecipientId { get; set; }
        public string Text { get; set; }

        public User Addresser { get; set; }
        public User Recipient { get; set; }
    }
}
