using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimatonEvent : MonoBehaviour
{
    //Spider scripti ile bağlantı kurmam gerekiyor
    private Spider _spider;

    private void Start()
    {
        //Bu script Sprite'ın altında
        //Biz ise Spider_Enemy parent'ımızın altındaki scripte ulaşmak istiyoruz.
        _spider = transform.parent.GetComponent<Spider>();  
    }


    public void Fire()
    {
      //  Debug.Log("Spider should fire!!");
        //Spider scriptindeki Attack methoduna ulaş
        _spider.Attack();
    }
}
