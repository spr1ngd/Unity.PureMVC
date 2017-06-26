namespace PureMVC.Interfaces
{
    using System;

    public interface IController
    {
        //执行事件
        void ExecuteCommand(INotification notification);
        //是否存在事件
        bool HasCommand(string notificationName);
        //注册事件
        void RegisterCommand(string notificationName, Type commandType);
        //移除事件
        void RemoveCommand(string notificationName);
    }
}