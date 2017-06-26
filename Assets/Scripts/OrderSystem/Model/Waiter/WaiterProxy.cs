
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 17:56:03
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class WaiterProxy : Proxy
    {
        public new const string NAME = "WaiterProxy";
        public IList<WaiterItem> Waiters
        {
            get { return (IList<WaiterItem>) base.Data; }
        }

        public WaiterProxy() : base(NAME,new List<WaiterItem>())
        {
            AddWaiter(new WaiterItem(1 , "小丽" , 0));
            AddWaiter(new WaiterItem(2 , "小红" , 1));
            AddWaiter(new WaiterItem(3 , "小花" , 0));
        }

        public void AddWaiter( WaiterItem item )
        {
            Waiters.Add(item);
        }
        public void RemoveWaiter( WaiterItem item ) 
        {
            Waiters.Remove(item);
        }
    }
}