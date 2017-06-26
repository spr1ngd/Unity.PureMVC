
/*=========================================
* Author: Administrator
* DateTime:2017/6/23 11:13:48
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;

namespace OrderSystem
{
    public class Order
    {
        public int id { get; set; }
        public ClientItem client { get; set; }
        public IList<MenuItem> menus { get; set; }
        public float pay
        {
            get
            {
                var money = 0.0f;
                foreach ( MenuItem menu in menus )
                    money += menu.price;
                return money;
            }
        }
        public string names
        {
            get
            {
                string name = "";
                foreach (MenuItem menu in menus)
                    name += menu.name + ",";
                return name;
            }
        }

        public Order( ClientItem client , IList<MenuItem> menus )
        {
            this.client = client;
            this.menus = menus;
        }
        public override string ToString()
        {
            return client.id + "号桌 " + client.population + "位顾客点餐" + menus.Count + "道,共消费" + pay + "元";
        }
    }
}
