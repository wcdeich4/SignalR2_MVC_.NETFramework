using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApp
{
    [HubName("mySignalRHub")]
    public class MySignalRHub : Hub
    {

        [HubMethodName("frontendToFrontend")]  //matches default
        public void FrontendToFrontend(string name, string message)
        {
            //Even though this is the Frontend to Frontend method,
            //the server can kind of comment in response if we want
            if (!SingletonGlobalDictionary.Instance.ContainsKey(name))
            {
                SingletonGlobalDictionary.Instance.Add(name, true);
                MySignalRHub.ServerToFrontend("MySignalRHub", "Greetings " + name + "!!!! You sent your first message at: " + DateTime.Now.ToLongDateString());
            }

            //send to all front end clients
            Clients.All.addNewMessageToPage(name, message);
        }

        [HubMethodName("ServerToFrontend")] //not default
        public static void ServerToFrontend(string name, string message)
        {

            IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<MySignalRHub>();
            _hubContext.Clients.All.addNewMessageToPage(name, message);
        }

        //public void Hello()
        //{
        //    Clients.All.hello();
        //}
    }
}