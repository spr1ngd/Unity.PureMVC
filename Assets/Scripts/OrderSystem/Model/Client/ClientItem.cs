
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 13:44:17
* Description:$safeprojectname$
==========================================*/

namespace OrderSystem
{
    public enum E_ClientState
    {
        WaitMenu = 0,
        WaitFood = 1,
        Pay = 2
    }

    public class ClientItem
    {
        public int id { get; set; }
        public int population { get; set; }
        public int state { get; set; }

        public ClientItem( int id , int population,int state )
        {
            this.id = id;
            this.population = population;
            this.state = state;
        }
        public override string ToString()
        {
            return id + "号桌" +"\n" + population + "个人" + "\n" + returnState(state);
        }
        private string returnState( int state )
        {
            if (state.Equals(0))
                return "等待菜单";
            if (state.Equals(1))
                return "等待上菜";
            if (state.Equals(2))
                return "就餐中";
            return "已经结账";
        }
    }
}