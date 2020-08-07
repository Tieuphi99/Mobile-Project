using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    protected float distance;
    protected bool isDead;
    protected Vector3 direction;
    [SerializeField] protected Transform pointA;
    [SerializeField] protected Transform pointB;
    [SerializeField] protected GameObject diamondPrefab;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Player player;

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        Movement();
    }

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Movement()
    {
        if (!isDead)
        {
            direction = transform.localPosition - player.transform.localPosition;
            sprite.flipX = direction.x > 0;
        }

        distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 2)
        {
            anim.SetBool("Combat_b", false);
        }

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") &&
            !anim.GetBool("Combat_b") && !isDead)
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
}