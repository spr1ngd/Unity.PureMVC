namespace PureMVC.Interfaces
{
    using System;

    public interface ICommand
    {
        //执行通知事件
        void Execute(INotification notification);
    }
}

