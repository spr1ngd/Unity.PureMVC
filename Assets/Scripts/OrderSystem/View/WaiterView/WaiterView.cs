
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 12:39:43
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace OrderSystem
{
    public class WaiterView : MonoBehaviour
    {
        public UnityAction CallWaiter = null;
        public UnityAction<Order> Order = null;
        public UnityAction Pay = null;
        public UnityAction CallCook = null;
        public UnityAction ServerFood = null;

        private ObjectPool<WaiterItemView> objectPool = null;
        private List<WaiterItemView> waiters = new List<WaiterItemView>();
        private Transform parent = null;

        private void Awake()
        {
            parent = this.transform.FindChild("Content");
            var prefab = Resources.Load<GameObject>("Prefabs/UI/WaiterItem");
            objectPool = new ObjectPool<WaiterItemView>(prefab , "WaiterPool");
        }
        public void UpdateWaiter( IList<WaiterItem> waiters )
        {
            for ( int i = 0 ; i < this.waiters.Count ; i++ )
                objectPool.Push(this.waiters[i]);

            this.waiters.AddRange(objectPool.Pop(waiters.Count));
            
            for ( int i = 0 ; i < this.waiters.Count ; i++ )
            {
                this.waiters[i].transform.SetParent(parent);
                var item = waiters[i];
                this.waiters[i].transform.FindChild("Id").GetComponent<Text>().text = item.ToString();
                Color color = Color.white;
                if ( item.state.Equals(0) )
                    color = Color.green;
                else if ( item.state.Equals(1) )
                    color = Color.yellow;
                else if ( item.state.Equals(2) )
                    color = Color.red;
                this.waiters[i].GetComponent<Image>().color = color;
            }
        }

        public void Move( WaiterItem waiter , ClientItem client )
        {

        }
    }
}