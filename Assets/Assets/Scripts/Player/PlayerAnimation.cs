using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    //  _swordAnimation Sword_Arc isimli Sprite'ın animator kısmını isimlendirdik.
    private Animator _swordAnimation;
    
    void Start()
    {     
        _anim = GetComponentInChildren<Animator>();
        // Player'imizin 2 tane Child'ı olduğu için transform.GetChild(1) kullandık.
        //0 ilk sprite 1 ise ikinci sprite'dır.
        _swordAnimation = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float move)
    {    
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }
    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _swordAnimation.SetTrigger("SwordAnimation");
    }
    public void Death()
    {
        _anim.SetTrigger("Death");
    }
}
