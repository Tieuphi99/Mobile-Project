using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public void Damage()
    {
        Health -= 1;
        if (Health < 1)
        {
            if (!isDead)
            {
                anim.SetTrigger("Death_t");
            }
            isDead = true;
        }
        else
        {
            anim.SetTrigger("Hit_t");
            anim.SetBool("Combat_b", true);
        }
    }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
}