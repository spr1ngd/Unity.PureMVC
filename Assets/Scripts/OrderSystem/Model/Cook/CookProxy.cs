
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 18:17:11
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using PureMVC.Patterns;

namespace OrderSystem
{
    public class CookProxy : Proxy
    {
        public new const string NAME = "CookProxy";
        public IList<CookItem> Cooks
        {
            get { return (IList<CookItem>) base.Data; }
        }

        public CookProxy( ) : base(NAME , new List<CookItem>())
        {
            AddCook(new CookItem(1 , "强尼" , 1));
            AddCook(new CookItem(2 , "托尼"));
            AddCook(new CookItem(3 , "鲍比" , 1));
            AddCook(new CookItem(4 , "缇米"));
        }
        public void AddCook( CookItem item )
        {
            Cooks.Add(item);
        }
        public void RemoveCook( CookItem item )
        {
            Cooks.Remove(item);
        }
    }
}