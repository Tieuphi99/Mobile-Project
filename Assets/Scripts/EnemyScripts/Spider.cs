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
        throw new System.NotImplementedException();
    }

    public override void Movement()
    {
        
    }

    public void FireAcidBall()
    {
        Instantiate(acidBall, transform.position, Quaternion.identity);
    }
}