using System.Collections;
using System.Collections.Generic;
//Import ettiğimiz library'den faydalanmak için
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Player : MonoBehaviour,IDamagable
{
    public int Health { get; set; }
    //Toplayacağım maddenin sayısı için isim
    public int diamonds;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _speed = 5f;
    private bool _resetJump = false;
    private bool _grounded = false;
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordArcSprite;
  
    void Start()
    {   
        _rigid= GetComponent<Rigidbody2D>();
        
        _playerAnim = GetComponent<PlayerAnimation>();
       
        _playerSprite = GetComponentInChildren<SpriteRenderer>();

        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        //Player canını 4 yaptık(4tane unitimiz vardı)
        Health = 4;

    }
    
    void Update()
    {
        Movement();
        //Atağı A butonun aayarladık
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true)
        {
            _playerAnim.Attack();
        }
    }
    void Movement()
    {   
        _grounded = IsGrounded();
        //sağ sol hareketi joystick'e verdik
        float move = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal");
        if (move > 0)
        {
            Flip(true);
        }
        else if (move < 0)
        {
            Flip(false);
        }
        
        //B butonunu zıplamaya atadık
        if (CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded() == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
          
            _playerAnim.Jump(true);

        }
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
      
        _playerAnim.Move(move);
        
    }
    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down,1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);  
        if (hitInfo.collider != null)
        {
            if (_resetJump == false)
            {
              
                _playerAnim.Jump(false);
                return true;
            }
        }
        return false;
    }
    void  Flip(bool faceRight)
    {
        if (faceRight == true)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
        if (faceRight == false)
        {
            _playerSprite.flipX = true;
            _playerSprite.flipX = true;
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;
            Vector3 newPos = _swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordArcSprite.transform.localPosition = newPos;
        }
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }

        Debug.Log("Damageable:Player");
        Health--; 
        UIManager.Instance.UpdateLives(Health);
        if (Health < 1)
        {
            _playerAnim.Death();
        }

    }
    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
}
