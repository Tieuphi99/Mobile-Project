using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public void Damage()
    {
        Debug.Log($"Hit {name}");
        Health -= 1;
        anim.SetTrigger("Hit_t");
        anim.SetBool("Combat_b", true);
        
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
}