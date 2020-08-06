using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _mossGiantAnim;

    private void Start()
    {
        _mossGiantAnim = GetComponentInChildren<Animator>();
    }

    public override void Update()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }

        if (!_mossGiantAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
    }
}