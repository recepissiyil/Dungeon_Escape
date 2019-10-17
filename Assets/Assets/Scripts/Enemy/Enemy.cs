using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    protected bool isHit = false;
    protected bool isDeath = false;
    
    [SerializeField]
    protected Transform pointA, pointB;
    protected Vector3 currenPosition;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Player player;
    //Diamond prefabı için prefab açtık
    public GameObject diamondPrefab;
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat")==false)
        {
            return;
        }
        if(isDeath==false)
        Movement();
    }

    public virtual void Movement()
    {
        if (currenPosition == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (transform.position == pointA.position)
        {

            currenPosition = pointB.position;
            anim.SetTrigger("Idle");
        }

        else if (transform.position == pointB.position)
        {

            currenPosition = pointA.position;
            anim.SetTrigger("Idle");
        }
        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currenPosition, speed * Time.deltaTime);
        }
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2.0f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        Vector3 direction = player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            sprite.flipX = true;
        }
    }
}
