
/*=========================================
* Author: Administrator
* DateTime:2017/6/21 14:03:08
* Description:$safeprojectname$
==========================================*/

using System.Collections.Generic;
using UnityEngine;
using System;

namespace OrderSystem
{
    public class ObjectPool<T> where T :MonoBehaviour
    {
        private string poolName = null;
        public string PoolName
        {
            get { return poolName; }
        }
        private GameObject prefab = null;
        private IList<GameObject> pool = null;
        public ObjectPool( GameObject prefab  , string name = "Pool" )
        {
            this.prefab = prefab;
            poolName = name;
            pool = new List<GameObject>();
        }

        public IList<T> Pop( int count )
        {
            IList<T> result = new List<T>();
            for ( int i = 0 ; i < count ; i++ )
                result.Add(Pop());
            return result;
        }
        public T Pop()
        {
            if (pool.Count > 0)
            {
                var result = pool[0];
                pool.RemoveAt(0);
                return result.GetComponent<T>();
            }
            return Create();
        }
        public void Push( GameObject go )
        {
            go.SetActive(false);
            pool.Add(go);
        }
        public void Push( T t)
        {
            Push(t.gameObject);
        }
        private T Create()
        {
            var obj = UnityEngine.Object.Instantiate(prefab);
            return obj.AddComponent<T>();
        }
    }
}