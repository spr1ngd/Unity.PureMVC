
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 18:04:49
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class MenuMediator : Mediator
    {
        private MenuProxy menuProxy = null;
        public new const string NAME = "MenuMediator";
        public MenuView MenuView
        {
            get { return (MenuView) ViewComponent; }
        }

        public MenuMediator( MenuView view ):base(NAME ,view)
        {
            MenuView.Submit += order => { SendNotification(OrderSystemEvent.SUBMITMENU , order); };
            MenuView.Cancel += () => { SendNotification(OrderSystemEvent.CANCEL_ORDER);};
        }

        public override void OnRegister( )
        {
            base.OnRegister();
            menuProxy = Facade.RetrieveProxy(MenuProxy.NAME) as MenuProxy;
            if(null == menuProxy)
                throw new Exception(MenuProxy.NAME + "is null!");
            MenuView.UpdateMenu(menuProxy.Menus);
        }

        public override IList<string> ListNotificationInterests( )
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.UPMENU);
            notifications.Add(OrderSystemEvent.CANCEL_ORDER);
            notifications.Add(OrderSystemEvent.SUBMITMENU);
            return notifications;
        }
        public override void HandleNotification( INotification notification )
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.UPMENU:
                    Order order = notification.Body as Order;
                    if( null == order)
                        throw new Exception("order is null ,plase check it!");
                    MenuView.UpMenu(order);
                    break;
                case OrderSystemEvent.SUBMITMENU:
                    Order selectedOrder = notification.Body as Order;
                    MenuView.SubmitMenu(selectedOrder);
                    SendNotification(OrderSystemEvent.ORDER , selectedOrder);
                    break;
                case OrderSystemEvent.CANCEL_ORDER:
                    MenuView.CancelMenu();
                    break;
            }
        }
    }
}