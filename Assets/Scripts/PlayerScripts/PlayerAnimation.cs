using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnim;
    private Animator _playerSwordAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponentInChildren<Animator>();
        _playerSwordAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    public void Move(float speed)
    {
        _playerAnim.SetFloat("Speed_f", Mathf.Abs(speed));
    }

    public void Jump(bool isJump)
    {
        _playerAnim.SetBool("Jump_b", isJump);
    }

    public void Attack()
    {
        _playerAnim.SetTrigger("Attack_t");
        _playerSwordAnim.SetTrigger("Sword_t");
    }

    public void Death()
    {
        _playerAnim.SetTrigger("Death_t");
    }
}
