using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chat
{
    public class ChatHub : Hub
    {
        public override Task OnConnected()
        {
            Connection.Users.Add(new User { Id = Context.ConnectionId });
            return base.OnConnected();
        }
        public void Send(string name, string message)
        {
                Connection.Users.Where(x => x.Id == Context.ConnectionId).FirstOrDefault().name = name;
                var client = Connection.Users.Where(a => a.name.Contains("Ramon")).FirstOrDefault().Id;
                Clients.Client(client).SendChat(name, message);
        }

    }
    public static class Connection
    {
        public static List<User> Users = new List<User>();
    }
    public class User
    {
        public string Id { get; set; }
        public string name { get; set; }

    }
}