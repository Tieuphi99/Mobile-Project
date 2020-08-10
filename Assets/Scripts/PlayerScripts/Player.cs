using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public int diamond;
    private Rigidbody2D _playerRb;
    private PlayerAnimation _playerAnimation;
    private SpriteRenderer _playerSpriteRenderer;
    private SpriteRenderer _swordArcSpriteRenderer;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float speed = 2.5f;
    private bool _isJumpAble;
    private bool _isOnGround;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordArcSpriteRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
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
        if (horizontalInput > 0)
        {
            _playerSpriteRenderer.flipX = false;
            _swordArcSpriteRenderer.flipY = false;

            Vector3 newSwordArcPos = _swordArcSpriteRenderer.transform.localPosition;
            newSwordArcPos.x = 1;
            _swordArcSpriteRenderer.transform.localPosition = newSwordArcPos;
            Vector3 newPlayerPos = _playerSpriteRenderer.transform.localPosition;
            newPlayerPos.x = 0.09f;
            _playerSpriteRenderer.transform.localPosition = newPlayerPos;
        }
        else if (horizontalInput < 0)
        {
            _playerSpriteRenderer.flipX = true;
            _swordArcSpriteRenderer.flipY = true;

            Vector3 newSwordArcPos = _swordArcSpriteRenderer.transform.localPosition;
            newSwordArcPos.x = -1;
            _swordArcSpriteRenderer.transform.localPosition = newSwordArcPos;
            Vector3 newPlayerPos = _playerSpriteRenderer.transform.localPosition;
            newPlayerPos.x = -0.09f;
            _playerSpriteRenderer.transform.localPosition = newPlayerPos;
        }
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

    public void Damage()
    {
        Health -= 1;
        if (Health < 0)
        {
            return;
        }

        UIManager.Instance.UpdateLives(Health);
        if (Health < 1)
        {
            _playerAnimation.Death();
        }
    }

    IEnumerator IsJumpAble()
    {
        _isJumpAble = true;
        yield return new WaitForSeconds(0.1f);
        _isJumpAble = false;
    }
}