using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private Vector3 _currentTarget;
    private Animator _mossGiantAnim;
    private SpriteRenderer _mossGiantSprite;

    private void Start()
    {
        _mossGiantAnim = GetComponentInChildren<Animator>();
        _mossGiantSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (!_mossGiantAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (_currentTarget == pointA.position)
            {
                _mossGiantSprite.flipX = true;
            }
            else
            {
                _mossGiantSprite.flipX = false;
            }

            if (transform.position == pointA.position)
            {
                _mossGiantAnim.SetTrigger("Idle_t");
                _currentTarget = pointB.position;
            }
            else if (transform.position == pointB.position)
            {
                _mossGiantAnim.SetTrigger("Idle_t");
                _currentTarget = pointA.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
    }
}