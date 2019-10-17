using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy,IDamagable
{
    public int Health { get; set; }
    public GameObject acidEffectPrefab;
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }
    public void Damage()
    {
        if (isDeath == true)
            return;
        Health--;
        if (Health < 1)
        {
            isDeath = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public override void Movement()
    {
        
    }
    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }
}
