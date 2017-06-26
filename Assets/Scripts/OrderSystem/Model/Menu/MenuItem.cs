
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:39:14
* Description:$safeprojectname$
==========================================*/

namespace OrderSystem
{
    public class MenuItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public bool instock { get; set; } //是否有货 true有货/false无货
        public bool iselected { get; set; }

        public MenuItem( int id ,string name,float price ,bool instock )
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.instock = instock;
            iselected = false;
        }
        public override string ToString()
        {
            return id + ":" + name + ":" + price + ":" + instock;
        }
    }
}