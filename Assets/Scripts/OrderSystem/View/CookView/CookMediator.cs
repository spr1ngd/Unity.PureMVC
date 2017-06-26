
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:22:49
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    public class CookMediator : Mediator
    {
        private CookProxy cookProxy = null;
        public new const string NAME = "CookMediator";
        public CookView CookView
        {
            get { return (CookView) base.ViewComponent; }
        }

        public CookMediator( CookView view ) : base(NAME , view)
        {
            CookView.CallCook += ( ) => { SendNotification(OrderSystemEvent.CALL_COOK); };
            CookView.ServerFood += ( ) => { SendNotification(OrderSystemEvent.SERVER_FOOD); };
        }

        public override void OnRegister( )
        {
            base.OnRegister();
            cookProxy = Facade.RetrieveProxy(CookProxy.NAME) as CookProxy;
            if(null == cookProxy)
                throw new Exception(CookProxy.NAME + "is null.");
            CookView.UpdateCook(cookProxy.Cooks);
        }

        public override IList<string> ListNotificationInterests( )
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.CALL_COOK);
            notifications.Add(OrderSystemEvent.SERVER_FOOD);
            return notifications;
        }

        public override void HandleNotification( INotification notification )
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.CALL_COOK:
                    Order order = notification.Body as Order;
                    if( null == order )
                        throw new Exception("order is null ,please check it.");
                    //todo 分配一个厨师开始做菜
                    Debug.Log("厨师接收到前台的订单,开始炒菜:" + order.names);
                    SendNotification(OrderSystemEvent.SERVER_FOOD,order);
                    break;
                case OrderSystemEvent.SERVER_FOOD:
                    Debug.Log("厨师通知服务员上菜");
                    SendNotification(OrderSystemEvent.FOOD_TO_CLIENT,notification.Body);
                    break;
            }
        }
    }
}