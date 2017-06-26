namespace PureMVC.Interfaces
{
    using System;

    public interface IModel
    {
        //是否存在代理
        bool HasProxy(string proxyName);
        //注册代理
        void RegisterProxy(IProxy proxy);
        //移除代理
        IProxy RemoveProxy(string proxyName);
        //回复代理
        IProxy RetrieveProxy(string proxyName);
    }
}

