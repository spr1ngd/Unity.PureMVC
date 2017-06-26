
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 18:04:39
* Description:$safeprojectname$
==========================================*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

namespace OrderSystem
{
    public class MenuView :MonoBehaviour
    {
        public UnityAction<Order> Submit = null;
        public UnityAction Cancel = null;

        private ObjectPool<MenuItemView> objectPool = null;
        private List<MenuItemView> menus = new List<MenuItemView>();
        private Transform parent = null;

        private void Awake( )
        {
            parent = this.transform.FindChild("Content");
            var prefab = Resources.Load<GameObject>("Prefabs/UI/MenuItem");
            objectPool = new ObjectPool<MenuItemView>(prefab , "MenuPool");
            transform.FindChild("SubmitButton").GetComponent<Button>().onClick.AddListener(() => { Submit(indexOrder); });
            transform.FindChild("CancelButton").GetComponent<Button>().onClick.AddListener(CancelMenu);
        }

        public void UpdateMenu( IList<MenuItem> menus )
        {
            for ( int i = 0 ; i < this.menus.Count ; i++ )
                objectPool.Push(this.menus[i]);

            this.menus.AddRange(objectPool.Pop(menus.Count));

            for ( int i = 0 ; i < this.menus.Count ; i++ )
            {
                this.menus[i].transform.SetParent(parent);
                var item = this.menus[i];
                item.InitData(menus[i]);
            }
        }

        private Order indexOrder = null;
        public void UpMenu( Order order )
        {
            ResetMenu();
            indexOrder = order;
            this.transform.localPosition = new Vector3(0 , 0 , 0);
        }

        public void SubmitMenu( Order order ) 
        {
            order.menus = GetSelected();
            CancelMenu();
        }

        public void CancelMenu()
        {
            this.transform.localPosition = new Vector3(0 , -800 , 0);
        }

        private IList<MenuItem> GetSelected()
        {
            IList<MenuItem> result = new List<MenuItem>();
            for (int i = 0; i < menus.Count; i++)
                if ( menus[i].Menu.iselected )
                    result.Add(menus[i].Menu);
            return result;
        }

        private void ResetMenu()
        {
            foreach (MenuItemView menu in menus)
                menu.toggle.isOn = false;
        }
    }
}