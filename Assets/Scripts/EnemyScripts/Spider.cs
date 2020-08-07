using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] private GameObject acidBall;

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
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

    public override void Movement()
    {
        
    }

    public void FireAcidBall()
    {
        Instantiate(acidBall, transform.position, Quaternion.identity);
    }
}