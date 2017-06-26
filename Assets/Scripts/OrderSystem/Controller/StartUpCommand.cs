
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:29:33
* Description:$safeprojectname$
==========================================*/

using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    internal class StartUpCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            //菜单代理
            MenuProxy menuProxy = new MenuProxy();
            Facade.RegisterProxy(menuProxy);

            //客户端代理
            ClientProxy clientProxy = new ClientProxy();
            Facade.RegisterProxy(clientProxy);

            //服务员代理
            WaiterProxy waitProxy = new WaiterProxy();
            Facade.RegisterProxy(waitProxy);

            //厨师代理
            CookProxy cookProxy = new CookProxy();
            Facade.RegisterProxy(cookProxy);

            OrderProxy orderProxy = new OrderProxy();
            Facade.RegisterProxy(orderProxy);

            MainUI mainUI = notification.Body as MainUI;

            if(null == mainUI)
                throw new Exception("程序启动失败..");
            Facade.RegisterMediator(new MenuMediator(mainUI.MenuView));
            Facade.RegisterMediator(new ClientMediator(mainUI.ClientView)); 
            Facade.RegisterMediator(new WaiterMediator(mainUI.WaitView));
            Facade.RegisterMediator(new CookMediator(mainUI.CookView));
        }
    }
}