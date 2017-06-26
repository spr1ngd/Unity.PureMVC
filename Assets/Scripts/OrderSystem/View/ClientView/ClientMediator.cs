
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:20:37
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class ClientMediator : Mediator
    {
        private ClientProxy clientProxy = null;
        public new const string NAME = "ClientMediator";
        private ClientView View
        {
            get { return (ClientView)ViewComponent; }
        }

        public ClientMediator( ClientView view ) : base(NAME , view)
        {
            view.CallWaiter += data => { SendNotification(OrderSystemEvent.CALL_WAITER , data); };
            view.Order += data => { SendNotification(OrderSystemEvent.ORDER , data); };
            view.Pay += ( ) => { SendNotification(OrderSystemEvent.PAY); };
        }

        public override void OnRegister()
        {
            base.OnRegister();
            clientProxy = Facade.RetrieveProxy(ClientProxy.NAME) as ClientProxy;
            if(null == clientProxy)
                throw new Exception("获取" + ClientProxy.NAME + "代理失败");
            View.UpdateClient(clientProxy.Clients);
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.CALL_WAITER);
            notifications.Add(OrderSystemEvent.ORDER);
            notifications.Add(OrderSystemEvent.PAY);
            return notifications;
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.CALL_WAITER:
                    ClientItem client = notification.Body as ClientItem;
                    if(null == client)
                        throw new Exception("对应桌号顾客不存在，请核对！");
                    Debug.Log(client.id + " 号桌顾客呼叫服务员 , 索要菜单 ");
                    break;
                case OrderSystemEvent.ORDER: 
                    Order order1 = notification.Body as Order;
                    if(null == order1)
                        throw new Exception("order1 is null ,please check it!");
                    order1.client.state++;
                    View.UpdateState(order1.client);
                    break;
                case OrderSystemEvent.PAY:
                    Order finishOrder = notification.Body as Order;
                    if ( null == finishOrder )
                        throw new Exception("finishOrder is null ,please check it!");
                    finishOrder.client.state++;
                    View.UpdateState(finishOrder.client);
                    SendNotification(OrderSystemEvent.GET_PAY, finishOrder);
                    break;
            }
        }
    }
}