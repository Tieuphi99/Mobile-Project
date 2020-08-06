﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float speed = 2.5f;
    private bool _isJumpAble;
    private bool _isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && _isOnGround)
        {
            _playerAnimation.Attack();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        _isOnGround = IsOnGround();
        
        Flip(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, jumpForce);
            _playerAnimation.Jump(true);
            StartCoroutine(IsJumpAble());
        }

        _playerRb.velocity = new Vector2(horizontalInput * speed, _playerRb.velocity.y);
        _playerAnimation.Move(horizontalInput);
    }

    private void Flip(float horizontalInput)
    {
        _playerSpriteRenderer.flipX = !(horizontalInput > 0);
    }

    private bool IsOnGround()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (!_isJumpAble)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }

        return false;
    }

    IEnumerator IsJumpAble()
    {
        _isJumpAble = true;
        yield return new WaitForSeconds(0.1f);
        _isJumpAble = false;
    }
}