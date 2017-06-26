
/*=========================================
* Author: Administrator
* DateTime:2017/6/22 17:02:17
* Description:$safeprojectname$
==========================================*/

using UnityEngine;
using UnityEngine.UI;

namespace OrderSystem
{
    public class MenuItemView : MonoBehaviour
    {
        public MenuItem Menu = null;

        public Toggle toggle = null;

        private void Awake()
        {
            toggle = transform.FindChild("Toggle").GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(isOn => { Menu.iselected = isOn; });
        }

        public void InitData( MenuItem menu ) 
        {
            Menu = menu;
            transform.FindChild("Price").GetComponent<Text>().text = menu.price + "元";
            string menuName = menu.name;
            if (!menu.instock)
                menuName += "（无货）";
            toggle.transform.FindChild("Label").GetComponent<Text>().text = menuName;
            toggle.interactable = menu.instock;
            toggle.isOn = menu.iselected;
        }
    }
}