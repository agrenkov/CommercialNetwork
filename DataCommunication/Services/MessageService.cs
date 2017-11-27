using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCommunication.DTO;
using DataCommunication.Interfaces;
using DatabaseLevel.Repositories;
using DatabaseLevel.Entities;

namespace DataCommunication.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRepository;

        public MessageService(IRepository<Message> messageRepository)
        {
            this._messageRepository = messageRepository;
        }

        public IEnumerable<MessageDto> GetUserDialogs(int userId)
        {
            var dialogs = _messageRepository.GetAll()
                .Where(x => x.ReceiverId == userId || x.SenderId == userId)
                .Select(x => new MessageDto()
                {
                    SenderId = x.SenderId,
                    ReceiverId = x.ReceiverId,
                    Message = x.Text,
                    DateTime = x.DateTime
                });
            return dialogs;
        }

        public IEnumerable<MessageDto> GetUserSpecificDialog(int senderId, int receiverId)
        {
            var dialogs = _messageRepository.GetAll()
                .Where(x => (x.SenderId == senderId && x.ReceiverId == receiverId)
                            || (x.SenderId == receiverId && x.ReceiverId == senderId))
                .Select(x => new MessageDto()
                {
                    SenderId = x.SenderId,
                    ReceiverId = x.ReceiverId,
                    Message = x.Text,
                    DateTime = x.DateTime
                });
            return dialogs;
        }

        public void AddMessage(Message message)
        {
            _messageRepository.Add(message);
            _messageRepository.Save();
        }

        public IEnumerable<Message> GetReceiverMessages(int receiverId)
        {
            return _messageRepository.GetAll().Where(x => x.ReceiverId == receiverId);
        }

        public IEnumerable<Message> GetSenderMessages(int senderId)
        {
            throw new System.NotImplementedException();
        }
    }
}
