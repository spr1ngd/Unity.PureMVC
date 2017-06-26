
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 19:21:23
* Description:$safeprojectname$
==========================================*/

using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    internal class WaiterMediator : Mediator
    {
        private WaiterProxy waiterProxy = null;
        public new const string NAME = "WaiterMediator";
        public WaiterView WaiterView
        {
            get { return (WaiterView) base.ViewComponent; }
        }

        //todo 订单代理
        private OrderProxy orderProxy = null;

        public WaiterMediator( WaiterView view ) : base(NAME, view)
        {
            WaiterView.CallWaiter += ( ) => { SendNotification(OrderSystemEvent.CALL_WAITER); };
            WaiterView.Order += data => { SendNotification(OrderSystemEvent.ORDER , data); };
            WaiterView.Pay += ( ) => { SendNotification(OrderSystemEvent.PAY); };
            WaiterView.CallCook += ( ) => { SendNotification(OrderSystemEvent.CALL_COOK); };
            WaiterView.ServerFood += ( ) => { SendNotification(OrderSystemEvent.SERVER_FOOD); };
        }

        public override void OnRegister( )
        {
            base.OnRegister();
            waiterProxy = Facade.RetrieveProxy(WaiterProxy.NAME) as WaiterProxy;
            orderProxy = Facade.RetrieveProxy(OrderProxy.NAME) as OrderProxy;
            if ( null == waiterProxy )
                throw new Exception(WaiterProxy.NAME + "is null,please check it!");
            if ( null == orderProxy )
                throw new Exception(OrderProxy.NAME + "is null,please check it!");
            WaiterView.UpdateWaiter(waiterProxy.Waiters);
        }

        public override IList<string> ListNotificationInterests( )
        {
            IList<string> notifications = new List<string>();
            notifications.Add(OrderSystemEvent.CALL_WAITER);
            notifications.Add(OrderSystemEvent.ORDER);
            notifications.Add(OrderSystemEvent.GET_PAY);
            notifications.Add(OrderSystemEvent.FOOD_TO_CLIENT);
            return notifications;
        }
        public override void HandleNotification( INotification notification )
        {
            switch (notification.Name)
            {
                case OrderSystemEvent.CALL_WAITER:
                    ClientItem client = notification.Body as ClientItem;
                    if(null == client)
                        throw new Exception("Client is null,please check it.");
                    Order order = new Order(client , new List<MenuItem>());
                    orderProxy.AddOrder(order);
                    Debug.Log(" 服务员给" + client.id + "号桌顾客拿菜单和订单 ");
                    SendNotification(OrderSystemEvent.UPMENU, order);
                    break;
                case OrderSystemEvent.ORDER:
                    SendNotification(OrderSystemEvent.CALL_COOK , notification.Body);
                    break;
                case OrderSystemEvent.GET_PAY:
                    Debug.Log(" 服务员拿到顾客的付款 ");
                    break;
                case OrderSystemEvent.FOOD_TO_CLIENT:
                    Debug.Log(" 服务员上菜 ");
                    SendNotification(OrderSystemEvent.PAY,notification.Body);
                    break;
            }
        }

        private WaiterItem GetIdleWaiter()
        {
            foreach (WaiterItem waiter in waiterProxy.Waiters)
                if ( waiter.state.Equals((int)E_WaiterState.Idle) )
                    return waiter;
            Debug.LogWarning("暂无空闲服务员请稍等..");
            return null;
        }
    }
}