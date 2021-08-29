using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using MTCmodel;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Hubs
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        //http://www.aspbucket.com/2016/03/implement-of-private-one-to-one-chat.html
        public class UserDetail
        {
            public string ConnectionId { get; set; }
            public string ClientID { get; set; }
            public bool IsAdmin { get; set; }
        }

        static List<UserDetail> ConnectedUsers = new List<UserDetail>();


        // "adminsConnected", true or false => voor clients
        // "clientOnline", UserID => voor admins
        // "receiveMessage", ChatMessage => zowel clients als admins
        // "clientsOnline", list of ConnectedUsers => voor admins
        // "clientOffline", item.ClientID);

        //========================================================================================================
        private readonly IApplicationRepository _repos;

        public ChatHub(
            IApplicationRepository appRepos)
        {
            _repos = appRepos;
        }
        //========================================================================================================
        public async Task Connect( string ClientId, bool IsAdmin = false)
        {
            var id = Context.ConnectionId;

            //misschien is de Connect methode al een  keer per ongeluk opgeroepen voor 
            //deze connectie, dan deze if niet uitvoeren
            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
            {
                ConnectedUsers.Add(new UserDetail { ConnectionId = id, ClientID = ClientId, IsAdmin= IsAdmin });
            }
            else
            {
                return;
            }

            if (IsAdmin)
            {
                //broadcast to alle Klanten (ook admin, maar we skippen dit in 
                // het winform programma)
                await Clients.All.SendAsync("adminsConnected", true);
                //terug sturen wie er allemaal online is
                List<String> connectedKlantenIDs = ConnectedUsers.Where(x => x.IsAdmin == false).Select(x => x.ClientID).Distinct().ToList();
                await Clients.Client(id).SendAsync("clientsOnline", connectedKlantenIDs);
            }
            else //Klant
            {
                //klant laten weten dat er een administrator online is of niet
                UserDetail adminAanwezig = ConnectedUsers.FirstOrDefault(x => x.IsAdmin == true);
                if (adminAanwezig == null)
                {
                    await Clients.Client(id).SendAsync("adminsConnected", false);
                }
                else
                {
                    await Clients.Client(id).SendAsync("adminsConnected", true);
                }
                //aan alle admins laten weten dat er een client online komt
                foreach (var admin in ConnectedUsers.Where(cu => cu.IsAdmin))
                {
                    await Clients.Client(admin.ConnectionId).SendAsync("clientOnline", ClientId);
                }
            }

        }

        public async Task SetClientMessagesAsReaded(string aClientId)
        {
            await _repos.ChatMessages.SetClientMessagesAsReaded(aClientId);
        }

        public async Task SetAdmindMessagesAsReaded(string aClientId)
        {
            await _repos.ChatMessages.SetAdmindMessagesAsReaded(aClientId);
        }

        public override Task OnConnectedAsync()
        {
            //just for testing
            //Console.WriteLine("Connect: " + Context.ConnectionId.ToString());
            return base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UserDetail item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if(item != null) //kan normaal niet maar stond in de tut
            {
                //connectie verwijderen uit onze lijst
                ConnectedUsers.Remove(item);

                //als alle connecties gesloten zijn van een bepaalde client
                if (ConnectedUsers.Where(u => u.ClientID == item.ClientID).Count() == 0)
                {
                    //als alle verwijderde van een admin komen
                    if (item.IsAdmin)
                    {
                        UserDetail adminAanwezig = ConnectedUsers.FirstOrDefault(x => x.IsAdmin == true);
                        //er zijn geen admins meer aanwezig
                        if(adminAanwezig == null)
                        {
                            //broadcast to alle Klanten
                            await Clients.All.SendAsync("adminsConnected", false);
                        }
                    }
                    //als alle verwijderde van een klant komen
                    else
                    {
                        //laten weten dat de client offline gaat aan alle admins
                        foreach (var admin in ConnectedUsers.Where(cu => cu.IsAdmin))
                        {
                             await Clients.Client(admin.ConnectionId).SendAsync("clientOffline", item.ClientID);
                        }
                    }
                }
            }
            //testing
            //Console.WriteLine("disconnet: " + Context.ConnectionId.ToString());
            //return base.OnDisconnectedAsync(exception);
        }

        public async Task SetAllAdminMessagesAsReaded(string aClientId)
        {
            await _repos.ChatMessages.SetAdmindMessagesAsReaded(aClientId);
        }

        public async Task SendMessage(ChatMessage aMessage)
        {
            //Console.WriteLine("test");
            try
            {
                await _repos.ChatMessages.AddAsync(aMessage);
                Console.WriteLine("");
            }
            catch(Exception ex)
            {
                return;
            }
            try
            {
                //is van admin, stuur dit naar de betreffende klant (of naar meerdere connecties van dezelfde klant);
                if (aMessage.IsFromAdmin)
                {
                    foreach (var item in ConnectedUsers.Where(x => x.ClientID == aMessage.CliendId))
                    {
                        await Clients.Client(item.ConnectionId).SendAsync("receiveMessage", aMessage);
                    }
                }
                //komt van een klant, 
                else
                {
                    //zend het naar alle admin
                    foreach (var item in ConnectedUsers.Where(x=>x.IsAdmin == true))
                    {
                        await Clients.Client(item.ConnectionId).SendAsync("receiveMessage", aMessage);
                    }
                    //zend naar client terug (ook al zijn connecties)
                    foreach (var item in ConnectedUsers.Where(x=>x.ClientID == aMessage.CliendId))
                    {
                        await Clients.Client(item.ConnectionId).SendAsync("receiveMessage", aMessage);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

    }
}


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

//public async Task SendMessage(string user, string message)
//{
//    await Clients.All.SendAsync("receiveMessage", user, message);
//}