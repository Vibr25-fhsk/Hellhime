using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class playercontorl_sc : MonoBehaviour
{

    //Helph
    public int PlayerHP = 100;
    public bool isFirstPlayer;
    public bool candie {get;protected set;}
    

    [SerializeField]protected bool God;

    #region Anim
    public Sprite[] IdleAnim;
    public Sprite[] RunAnim;
    public Animationscript animscript;
    #endregion
    public attack attackscript;

    #region movement
    [SerializeField]private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveinput;
    float horizontalMovement;
    #endregion
    BoxCollider2D PlayerColl;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerColl = GetComponent<BoxCollider2D>();

        animscript.ChangeAnimation(IdleAnim);

        rb = GetComponent<Rigidbody2D>(); 
        animscript = GetComponent<Animationscript>();
    }
    
    void Awake()
    {
        if(God)
        {
            candie =false;
            PlayerHP = PlayerHP * 100;
            //PlayerColl =false;
            rb.gravityScale=0;
        }

        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isFirstPlayer == true)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal_P2");
        }

        if(animscript.CurrentAnimation != attackscript.ThrowAnim && animscript.CurrentAnimation != attackscript.SlashAnim)
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y );
        }
        else if(animscript.CurrentAnimation == attackscript.ThrowAnim)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y );
        }
        
        
         
        if (rb.linearVelocity.x <= 0.5 && attackscript.isAttacking == false && animscript.CurrentAnimation != IdleAnim )
        {
            
            animscript.ChangeAnimation(IdleAnim);


        }
        if(rb.linearVelocityX<0)
        {
            
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if(rb.linearVelocityX>0)
        {
            
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(PlayerHP<=0)
        {
            Destroy(gameObject);
        }

    }


    public void Move(InputAction.CallbackContext moveContext)
    {
        moveinput = moveContext.ReadValue<Vector2>();
    }

    #region Colliders
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(candie)
        {
           if(other.gameObject.tag=="kastkniv")
            {
            PlayerHP = PlayerHP -10;
            } 
            else if(other.gameObject.tag=="dolk")
            {
            PlayerHP = PlayerHP -20;
            }  
        }
        
    }
    #endregion

}
