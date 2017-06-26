
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 13:48:51
* Description:$safeprojectname$
==========================================*/


using System.Collections.Generic;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class ClientProxy : Proxy
    {
        public new const string NAME = "ClientProxy";
        public IList<ClientItem> Clients
        {
            get { return (IList<ClientItem>)base.Data; }
        }

        public ClientProxy() : base(NAME , new List<ClientItem>())
        {
            AddClient(new ClientItem(1 , 2 , 0));
            AddClient(new ClientItem(2 , 1 , 1));
            AddClient(new ClientItem(3 , 4 , 1));
            AddClient(new ClientItem(4 , 5 , 2));
            AddClient(new ClientItem(5 , 12 , 0));
        }

        public void AddClient( ClientItem item )
        {
            UpdateClient(item);
            Clients.Add(item);
        }
        public void DeleteClient( ClientItem item )
        {
            Clients.Remove(item);
        }
        public void UpdateClient( ClientItem item ) 
        {
            for ( int i = 0 ; i < Clients.Count ; i++ )
            {
                if ( Clients[i].id == item.id )
                {
                    Clients[i] = item;
                    return;
                }
            }
        }
    }
}