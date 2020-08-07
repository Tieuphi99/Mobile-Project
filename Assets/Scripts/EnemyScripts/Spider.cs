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

    public override void Movement()
    {
    }

    public void FireAcidBall()
    {
        Instantiate(acidBall, transform.position, Quaternion.identity);
    }
}