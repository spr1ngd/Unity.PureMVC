
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:39:06
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using PureMVC.Patterns;


namespace OrderSystem
{
    public class MenuProxy :Proxy
    {
        public new const string NAME = "MenuProxy";

        public IList<MenuItem> Menus
        {
            get { return (IList<MenuItem>)base.Data; }
        }

        public MenuProxy( ) : base ( NAME,new List<MenuItem>())
        {
            AddMenu(new MenuItem(1 , "小龙虾" , 99 , true));
            AddMenu(new MenuItem(2 , "米饭" , 5 , true));
            AddMenu(new MenuItem(3 , "土豆牛肉" , 49 , true));
            AddMenu(new MenuItem(4 , "豆腐" , 13 , false));
            AddMenu(new MenuItem(5 , "蛋汤" , 9 , true));
            AddMenu(new MenuItem(6 , "小炒肉" , 29 , true));
            AddMenu(new MenuItem(7 , "驴肉火烧" , 9 , false));
            AddMenu(new MenuItem(8 , "火锅" , 119 , true));
            AddMenu(new MenuItem(9 , "包子" , 5 , true));
            AddMenu(new MenuItem(10 , "馒头" , 2 , true));
        }

        public void AddMenu( MenuItem item )
        {
            if (!Menus.Contains(item))
            {
                Menus.Add(item);
            }
        }
        public void Remove( MenuItem item )
        {
            if (Menus.Contains(item))
            {
                Menus.Remove(item);
            }
        }
        public void OutOfStock( MenuItem item )
        {
            foreach (MenuItem menuItem in Menus)
            {
                if ( menuItem.id == item.id )
                {
                    menuItem.instock = false;
                    return;
                }
            }
        }
    }
}
