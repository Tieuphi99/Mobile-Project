using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    public void Damage()
    {
        throw new System.NotImplementedException();
    }

    public override void Movement()
    {
        
    }
}