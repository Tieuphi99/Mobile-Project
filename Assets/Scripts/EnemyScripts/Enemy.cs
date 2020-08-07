using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA;
    [SerializeField] protected Transform pointB;
    [SerializeField] protected Vector3 currentTarget;
    [SerializeField] protected Animator anim;
    [SerializeField] protected SpriteRenderer sprite;

    private void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public virtual void Movement()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            if (currentTarget == pointA.position)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

            if (transform.position == pointA.position)
            {
                anim.SetTrigger("Idle_t");
                currentTarget = pointB.position;
            }
            else if (transform.position == pointB.position)
            {
                anim.SetTrigger("Idle_t");
                currentTarget = pointA.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
    }

    public virtual void Update()
    {
        Movement();
    }
}