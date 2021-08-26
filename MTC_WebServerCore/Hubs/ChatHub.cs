using Microsoft.AspNetCore.SignalR;
using MTCmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Hubs
{
    public class ChatHub : Hub
    {
        //create the model

        //create the repository

        //migration

        //update-database

        //make this class

        //in startup: services.AddSignalR();

        //in startup:
        //app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapHub<ChatHub>("/pathtothecontrollerEnAction");
        //    });


        //install clientlib signalr.js

        //copy the signalrReqHandler.js file in the js folder (maybe change withUrlpath in the file)


        //public async Task SendMessage(ChatMessage aChatmessage)
        //{
        //    await Clients.All.SendAsync("receiveMessage", aChatmessage);
        //}




        //tut 2
        //https://www.youtube.com/watch?v=59UJHupjB_w

        //installing de clientlib 0:43
        //make this file
        //startup, 2 dingen adden, de service en de route
        //view maken

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("receiveMessage", user, message);
        }
    }
}
