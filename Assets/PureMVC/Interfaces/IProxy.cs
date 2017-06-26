namespace PureMVC.Interfaces
{
    using System;

    public interface IProxy
    {
        //注册
        void OnRegister();
        //注销
        void OnRemove();

        //原始数据
        object Data { get; set; }
        //代理名称
        string ProxyName { get; }
    }
}

