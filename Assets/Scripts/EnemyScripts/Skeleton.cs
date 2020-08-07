using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }

    public void Damage()
    {
        Debug.Log("HIT");
        Health -= 1;
        anim.SetTrigger("Hit_t");
        
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}