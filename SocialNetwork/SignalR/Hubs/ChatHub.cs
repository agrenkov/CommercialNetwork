using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.Identity;
using SocialNetwork.Models;

namespace SocialNetwork.SignalR.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static List<UserModel> _connections = new List<UserModel>();

        public static void Send(int senderId, string receiverName, string message)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            var connectionId = _connections.Where(x => x.Name == receiverName).Select(x => x.ConnectionId).FirstOrDefault();
            if (connectionId != null)
                context.Clients.Client(connectionId).addNewMessageToPage(senderId, message);
        }

        public override Task OnConnected()
        {
            var user = new UserModel()
            {
                Name = Context.User.Identity.GetUserName(),
                ConnectionId = Context.ConnectionId
            };
            _connections.Add(user);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            _connections.Remove(_connections.FirstOrDefault(x => x.Name == name));

            return base.OnDisconnected(stopCalled);
        }
    }
}