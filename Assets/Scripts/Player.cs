using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _playerRb;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float speed = 2.5f;
    private bool _isJumpAble;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRb.velocity = new Vector2(horizontalInput * speed, _playerRb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, jumpForce);
            StartCoroutine(IsJumpAble());
        }
    }

    private bool IsOnGround()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (!_isJumpAble)
            {
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