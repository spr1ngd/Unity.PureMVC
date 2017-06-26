
/*=========================================
* Author: Administrator
* DateTime:2017/6/23 11:13:56
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class OrderProxy : Proxy
    {
        public new const string NAME = "OrderProxy";
        public IList<Order> Orders
        {
            get { return (IList<Order>)base.Data; }
        }

        public OrderProxy( ) : base(NAME , new List<Order>())
        {
            //todo 订单应该自来于顾客
        }

        public void AddOrder( Order order )
        {
            order.id = Orders.Count + 1;
            Orders.Add(order);
        }
        public void RemoveOrder( Order order  )
        {
            Orders.Remove(order);
        }
    }
}