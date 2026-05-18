using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class playercontorl_sc : MonoBehaviour
{

    #region Helph
    public int PlayerHP = 100;
    public int maxHP { get; private set; } = 100;
    public bool isFirstPlayer;
    public bool candie;
    protected Slider HealthbarP1;
    protected Slider HealthbarP2;
    #endregion
    

    [SerializeField]protected bool God;

    #region Anim
    public Sprite[] IdleAnim;
    public Sprite[] RunAnim;
    public Animationscript animscript;
    #endregion
    public attack Attack;
    public Dolkslash_attack Dolkslash;
    public knivkast_attack Knivkast;
    WallofStone RaiseRock;
    
    #region movement
    [SerializeField]private float moveSpeed = 5f;
    [SerializeField]private float jumpForce = 1f;
    private Rigidbody2D rb;
    private Vector2 moveinput;
    float horizontalMovement;
    float VerticalMovement;
    public bool isGrounded {get; private set;}
    [SerializeField]protected bool isMoving;
    [SerializeField]protected bool P2isMoving;
    #endregion
    #region  Misc
    protected bool P1Lost;
    protected bool P2Lost;
    GameManeger GM;
    SpriteRenderer SpriteRender;
    ParticleSystem P1DeathFx;
     ParticleSystem P2DeathFx;
    ParticleSystem P1DustFx;
    ParticleSystem P2DustFx;
    BoxCollider2D PlayerColl;

    [SerializeField] protected float DeathDlay = 1f;
    #endregion
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaiseRock = GetComponent<WallofStone>();
        PlayerColl = GetComponent<BoxCollider2D>();
        //animscript.ChangeAnimation(RaiseRock.StompAnim);
        rb = GetComponent<Rigidbody2D>(); 
        animscript = GetComponent<Animationscript>();
        animscript.ChangeAnimation(IdleAnim);
        SpriteRender = GetComponent<SpriteRenderer>();
        
        if(gameObject.tag=="Player1")
        {
            HealthbarP1 = GameObject.Find("healthbarP1").GetComponent<Slider>();
            P1DeathFx = GameObject.Find("DeathFX").GetComponent<ParticleSystem>();
            P1DustFx = GameObject.Find("DustFX").GetComponent<ParticleSystem>();
            HealthbarP1.maxValue = maxHP;
            HealthbarP1.value = PlayerHP;
        }
        else if(gameObject.tag=="Player2")
        {
            HealthbarP2 = GameObject.Find("healthbarP2").GetComponent<Slider>();
            P2DeathFx = GameObject.Find("P2DeathFX").GetComponent<ParticleSystem>();
            P2DustFx = GameObject.Find("P2DustFX").GetComponent<ParticleSystem>();
            HealthbarP2.maxValue = maxHP;
            HealthbarP2.value = PlayerHP;
        }
        GM = GameObject.Find("Hella_GM").GetComponent<GameManeger>();
        
    }
    
    protected void GOD()
    {
        if(gameObject.tag=="Player1")
        {
            if(God)
            {
                candie =false;
                //PlayerHP = PlayerHP * 100;
                //PlayerColl =false;
                //rb.gravityScale=0f;
            }
            else
            {
                candie = true;
                //rb.gravityScale=1f;
            }
        }
        else if(gameObject.tag=="Player2")
        {
            if(God)
            {
                candie =false;
                //PlayerHP = PlayerHP * 100;
                //PlayerColl =false;
                //rb.gravityScale=0f;
            }
            else
            {
                candie = true;
                //rb.gravityScale=1f;
            }
        }

        
    }
    
    // Update is called once per frame
    void Update()
    {   
        if(P1Lost)
        {
            GM.P2Wins++;
            P1Lost = false;
        }
        if(P2Lost)
        {
            GM.P1Wins++;
            P2Lost = false;
        }
        #region Player1
        if(gameObject.tag=="Player1")
        {
            HealthbarP1.value = PlayerHP;
            if(rb.linearVelocityX<0 && isMoving)
            {
                
                transform.rotation = Quaternion.Euler(0,180,0);
                P1DustFx.Play();
            }
            else if(rb.linearVelocityX>0 && isMoving)
            {
                
                transform.rotation = Quaternion.Euler(0,0,0);
                P1DustFx.Play();
            }
            
            if(Input.GetButton("Gmode_P1"))
            {
                God = true;
            }
            if (Input.GetButton("Smode_P1"))
            {
                God = false;
            }
            GOD();
            if(PlayerHP<=0)
            {
                SpriteRender.enabled = false;
                if(P1DeathFx.isPlaying==false)
                {
                    P1DeathFx.Play();
                }
                P1Lost = true;
                WaitForSeconds wait = new WaitForSeconds(DeathDlay);
                gameObject.tag = "Dead";
                //Destroy(gameObject,DeathDlay);
                
            }

        }
        #endregion
        #region Player2
        if(gameObject.tag=="Player2")
        {
            HealthbarP2.value = PlayerHP;
            if(rb.linearVelocityX<0 && P2isMoving)
            {
                
                transform.rotation = Quaternion.Euler(0,180,0);
                P2DustFx.Play();
            }
            else if(rb.linearVelocityX>0 && P2isMoving)
            {
                
                transform.rotation = Quaternion.Euler(0,0,0);
                P2DustFx.Play();
            }
            if(PlayerHP<=0)
            {
                
                SpriteRender.enabled = false;
                if(P2DeathFx.isPlaying==false)
                {
                    P2DeathFx.Play();
                }
                P2Lost = true;
                WaitForSeconds wait = new WaitForSeconds(DeathDlay);
                gameObject.tag = "Dead";
                //Destroy(gameObject,DeathDlay);
                
            }

            if(Input.GetButton("Gmode_P2"))
            {
                God = true;
            }
            if (Input.GetButton("Smode_P2"))
            {
                God = false;
            }
            GOD();
            
        }
        #endregion
        
        #region Inputs/movement modifiers
        if(isFirstPlayer == true)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            VerticalMovement = Input.GetAxisRaw("Jump");
            
            if(Input.GetButton("Jump")&& isGrounded)
            {
                rb.AddForce(new Vector2(rb.linearVelocityX, VerticalMovement * jumpForce), ForceMode2D.Impulse);
                P1DustFx.Play();
            }
            if(horizontalMovement>=0.1f)
            {
                isMoving = true;
            }
            else if(horizontalMovement<=-0.1f)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal_P2");
            VerticalMovement = Input.GetAxisRaw("Jump_p2");
            if(Input.GetButton("Jump_p2")&& isGrounded)
            {
                rb.AddForce(new Vector2(rb.linearVelocityX, VerticalMovement * jumpForce), ForceMode2D.Impulse);
                P2DustFx.Play();
            }
            if(horizontalMovement>=0.1f)
            {
                P2isMoving = true;
            }
            else if(horizontalMovement<=-0.1f)
            {
                P2isMoving = true;
            }
            else
            {
                P2isMoving = false;
            }

        }

        if(animscript.CurrentAnimation != Knivkast.ThrowAnim && animscript.CurrentAnimation != Dolkslash.SlashAnim && animscript.CurrentAnimation != RaiseRock.StompAnim)
        {
            rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y );
            

        }
        else if(animscript.CurrentAnimation ==Knivkast.ThrowAnim || animscript.CurrentAnimation == RaiseRock.StompAnim)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y );
        }

        
        if (rb.linearVelocity.x <= 0.5 && Attack.isAttacking == false && animscript.CurrentAnimation != IdleAnim && animscript.CanchangeAnim == true)
        {
            animscript.ChangeAnimation(IdleAnim);
            
        }
        #endregion

        
        /*
        if(animscript.Frameindex==RaiseRock.StompAnim.Length-1 || animscript.Frameindex==Knivkast.ThrowAnim.Length-1 || animscript.Frameindex==Dolkslash.SlashAnim.Length-1)
        {

            if (rb.linearVelocity.x <= 0.5 && Attack.isAttacking == false && animscript.CurrentAnimation != IdleAnim )
            {
                animscript.ChangeAnimation(IdleAnim);
            }  
        }
        */
    }
    void FixedUpdate()
    {
        if(PlayerHP<=0)
        {
            PlayerHP = 0;
        }
    }
    

    public void Move(InputAction.CallbackContext moveContext)
    {
        moveinput = moveContext.ReadValue<Vector2>();
    }

    #region Colliders
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Border")
        {
            PlayerHP = PlayerHP -1000;
        }
        
        if(candie)
        {
           if(other.gameObject.tag=="kastkniv" || other.gameObject.tag=="kastknivP2")
            {
            PlayerHP = PlayerHP -10;
            } 
            else if(other.gameObject.tag=="dolk" || other.gameObject.tag=="dolkP2")
            {
            PlayerHP = PlayerHP -20;
            }  
        }
        if(other.gameObject.tag=="Ground")
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag=="Ground")
        {
            isGrounded = false;
        }
    }
    #endregion

}
