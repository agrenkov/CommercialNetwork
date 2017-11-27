using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCommunication.DTO;
using DatabaseLevel.Entities;

namespace DataCommunication.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageDto> GetUserDialogs(int userId);
        IEnumerable<MessageDto> GetUserSpecificDialog(int senderId, int receiverId);
        IEnumerable<Message> GetSenderMessages(int senderId);
        IEnumerable<Message> GetReceiverMessages(int receiverId);
        void AddMessage(Message message);
    }
}
