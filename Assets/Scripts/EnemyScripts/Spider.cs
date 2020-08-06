using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
    private Vector3 _currentTarget;
    private Animator _spiderGiantAnim;
    private SpriteRenderer _spiderGiantSprite;

    private void Start()
    {
        _spiderGiantAnim = GetComponentInChildren<Animator>();
        _spiderGiantSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void Update()
    {
        if (!_spiderGiantAnim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (_currentTarget == pointA.position)
            {
                _spiderGiantSprite.flipX = true;
            }
            else
            {
                _spiderGiantSprite.flipX = false;
            }

            if (transform.position == pointA.position)
            {
                _spiderGiantAnim.SetTrigger("Idle_t");
                _currentTarget = pointB.position;
            }
            else if (transform.position == pointB.position)
            {
                _spiderGiantAnim.SetTrigger("Idle_t");
                _currentTarget = pointA.position;
            }

            transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
        }
    }
}