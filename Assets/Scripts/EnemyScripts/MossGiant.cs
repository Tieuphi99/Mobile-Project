﻿using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public void Damage()
    {
        if (isDead)
        {
            return;
        }

        Health -= 1;
        if (Health < 1)
        {
            anim.SetTrigger("Death_t");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
            Diamond diamondScript = diamond.GetComponent<Diamond>();
            diamondScript.gems = gems;
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