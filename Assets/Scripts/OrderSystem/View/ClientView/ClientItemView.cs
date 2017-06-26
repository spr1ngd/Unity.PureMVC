
/*=========================================
* Author: Administrator
* DateTime:2017/6/22 16:47:56
* Description:$safeprojectname$
==========================================*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace OrderSystem
{
    public class ClientItemView : MonoBehaviour
    {
        private Text text = null;
        private Image image = null;
        public ClientItem client = null;

        private void Awake()
        {
            text = transform.FindChild("Id").GetComponent<Text>();
            image = transform.GetComponent<Image>();
        }

        public void InitClient( ClientItem client )
        {
            this.client = client;
            UpdateState(); 
        }

        private void UpdateState(  )
        {
            Color color = Color.white;
            if ( this.client.state.Equals(0) )
                color = Color.green;
            else if ( this.client.state.Equals(1) )
                color = Color.yellow;
            else if ( this.client.state.Equals(2) )
            {
                color = Color.red;
                StartCoroutine(eatting());
            }
            image.color = color;
            text.text = client.ToString();
        }

        private IEnumerator eatting( float time = 5 )
        {
            Debug.Log(client.id + "号桌客人正在就餐");
            yield return new WaitForSeconds(time);
            Debug.Log(client.id + "客人离开饭店");
            client = null;
            text.text = "该桌子暂无客人";
            image.color = Color.white;
        }
    }
}