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

    public override void Movement()
    {
        base.Movement();
        Debug.Log($"Distance: {distance}");
    }

    public void Damage()
    {
        Debug.Log("HIT");
        Health -= 1;
        anim.SetTrigger("Hit_t");
        anim.SetBool("Combat_b", true);
        
        if (Health < 1)
        {
            Destroy(gameObject);
        }
    }
}