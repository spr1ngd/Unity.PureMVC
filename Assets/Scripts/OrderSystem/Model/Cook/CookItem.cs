
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 18:17:04
* Description:$safeprojectname$
==========================================*/

namespace OrderSystem
{
    public class CookItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public string cooking { get; set; }

        public CookItem( int id , string name , int state = 0 , string cooking = "" )
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.cooking = cooking;
        }
        public override string ToString()
        {
            return id + "号厨师\n" + name + "\n" + resultState();
        }
        private string resultState()
        {
            if (state.Equals(0))
                return "休息中";
            return "忙碌中";
        }
    }
}