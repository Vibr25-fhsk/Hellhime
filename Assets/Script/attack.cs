using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Mono.Cecil.Cil;
using UnityEditor.Rendering;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR;
public class attack : MonoBehaviour
{
    
    public Animationscript animscript;
    public Sprite[] ThrowAnim;
    public Sprite[] SlashAnim;

    public bool isFirstPlayer;

    
    [SerializeField]protected float cordx =0.5f;
    
    public bool Kast = false;
    [SerializeField]float cooldown = 1f;
    //AnimatorStateInfo stateInfo;
    public Transform spawnpoint;
    public Transform hand;
    #region Weapons
    public int Knivcount;
    public int Dolkcount;
    public int KnivcountP2;
    public int DolkcountP2;

    public GameObject Kastkniv;
    public GameObject Dolk;

    public GameObject KastknivP2;
    public GameObject DolkP2;

    public GameObject Rapier;
    #endregion
    
    #region misc
    public GameObject Sten;
    GameObject Stentemp;
    public GameObject StenP2;
    GameObject StentempP2;


    protected int StenCount;
    protected int StenCountP2;

    #endregion
    
    public bool canAttack = true;
    public bool canAttackP2 = true;
    Animator anim;
    [SerializeField]public bool Attack_mainP1;
    [SerializeField]public bool Attack_subP1;

    [SerializeField]public bool Attack_mainP2;
    [SerializeField]public bool Attack_subP2;

    public bool Defens_mainP1;
    public bool Defens_mainP2;
    
    public bool isAttacking{get; private set;}

    
    

    Vector2 stenpos;

    #region old code //inaktive
    /*
    void Start()
    {

        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);

        //Debug.Log(gameObject.tag);
    }

    void FixedUpdate()
    {
        
        Debug.Log("State: " + stateInfo.IsName("Throwattack") + " Time: " + stateInfo.normalizedTime);
    }
    void Throw()
    {
        if(canAttack == true)
        {
        
            if(Attack_mainP1 == true && Attack_subP1 == false)
            {
                //AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                
                anim.SetTrigger("Throw");
                if(stateInfo.IsName("Throwattack") && stateInfo.normalizedTime >= 0.9f)
                {
                    Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
                    
                }
                
            
                //Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
                //knifeamount++;
            }
            
            //else if(Attack_mainP1 == false)
            //{
                //anim.ResetTrigger("Throw");    
            //}

        
        }
        
    }
    
    void slash()
    {
        if(canAttack == true)
        {
            if(Attack_subP1 == true && Attack_mainP1 == false)
            {
                anim.SetTrigger("Slash");

                if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
                {
                    Instantiate(Dolk, transform.position, transform.rotation);
                }
                
                Instantiate(Dolk, transform.position, transform.rotation);
                

                
            }
            
            else if(Attack_subP1 == false)
            {
                //anim.ResetTrigger("Slash");
                //if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Slash"))
                //{
                 //   Destroy(Dolk);
                //}
                
            } 
            
            //Debug.Log("Slash:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("Slashattack"));
        }

    }


    #region Attack inputs
    void Update()
    {
        
       if (gameObject.tag == "Player1")
        {
            //main attack
            if(Input.GetButtonDown("Attack1_p1"))
            {
                
                if(canAttack == true)
                {
                    Attack_mainP1 = true;
                    Throw();
                    
                }
                else if(canAttack == false)
                {
                    Attack_mainP1 = false;
                } 
            }

            else if(Input.GetButtonUp("Attack1_p1"))
            {
                StartCoroutine(attack_cld());
                Attack_mainP1 = false;
            }
            //sub attack
            else if(Input.GetButtonDown("Attack2_p1"))
            {
                if(canAttack == true)
                {
                    Attack_subP1 = true;
                    slash();
                }
                else if(canAttack == false)
                {
                    Attack_subP1 = false;
                }

            }
            else if(Input.GetButtonUp("Attack2_p1"))
            {
                StartCoroutine(attack_cld());
                Attack_subP1 = false;
            }
            
        }
        else if(gameObject.tag == "Player2")
        {
            //main attack
            if(Input.GetButtonDown("Attack1_p2"))
            {
                
                if(canAttack)
                {
                    Attack_mainP2 = true;
                }
                else if(canAttack == false)
                {
                    Attack_mainP2 = false;
                }
                
            }
            else if(Input.GetButtonUp("Attack1_p2"))
            {
                StartCoroutine(attack_cld());
                Attack_mainP2 = false;
            }
            //sub attack
            if(Input.GetButtonDown("Attack2_p2"))
            {
                
                if(canAttack)
                {
                    Attack_subP2 = true;
                }
                else if(canAttack == false)
                {
                    Attack_subP2 = false;
                }
                
            }
            else if(Input.GetButtonUp("Attack2_p2"))
            {
                StartCoroutine(attack_cld());
                Attack_subP2 = false;
            }
            

        }
    #endregion
        if(Attack_mainP1 == true || Attack_subP1 == true || Attack_mainP2 == true || Attack_subP2 == true)
        {
            isAttacking = true;
        }
        else if(Attack_mainP1 == false && Attack_subP1 == false && Attack_mainP2 == false && Attack_subP2 == false)
        {
            isAttacking = false;
            //Debug.Log("Idle:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("idel"));
        }

        //Debug.Log("Value: " + cooldown); 
    }
    public IEnumerator attack_cld()
    {
        
        if(isAttacking)
        {

            canAttack = false;
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
        
 
        }


        //GetComponent<CapsuleCollider2D>().enabled = false;
    }
    */
    #endregion

    #region new code
    
        void Start()
    {

        /*
        if (gameObject.tag=="Player1")
        {
            
            animscript.ChangeAnimation(ThrowAnim);
        }
        */
        anim = GetComponent<Animator>();
        //anim.SetBool("isIdle", true);

        //Debug.Log(gameObject.tag);
    }

    void Awake()
    {
        if(gameObject.tag=="Player1")
        {
             
            isFirstPlayer = true;
        }
        else if (gameObject.tag=="Player2")
        {
            
            isFirstPlayer=false;
            //animscript.ChangeAnimation(ThrowAnim);
        }
        
    }
    void Throw()
    {
        if(canAttack == true && isFirstPlayer == true)
        {
            
            if(Attack_mainP1 == true && Attack_subP1 == false)
            {
                animscript.ChangeAnimation(ThrowAnim);
                animscript.CanchangeAnim = false;
            }
            
            else if(Attack_mainP1 == false)
            {
                //Kast = false;
                //anim.ResetTrigger("Throw");    
            }
        }

        //Debug.Log("Throw:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("Throwattack"));
        if(canAttack == true && isFirstPlayer==false)
        {
            if(Attack_mainP2 == true && Attack_subP1 == false)
            {
                //Debug.Log("Is throwing knife");
                animscript.ChangeAnimation(ThrowAnim);
                animscript.CanchangeAnim = false;
            }
            else if(Attack_mainP2 == false)
            {
                
            }
        }   
    }
    void Def()
   {
        if (Stentemp == null)
        {
            if(Defens_mainP1 ==true && Attack_mainP1 == false && Attack_subP1 == false)
            {
                canAttack=false;
                Stentemp = Instantiate(Sten,stenpos,Quaternion.identity);
                Stentemp.transform.rotation = transform.rotation;
            }
            
        }
        else
        {
            return;
        }
    
        if (StentempP2 == null)
        {
            if(Defens_mainP2 ==true && Attack_mainP2 == false && Attack_subP2 == false)
            {
                canAttack=false;
                StentempP2 = Instantiate(StenP2,stenpos,Quaternion.identity);
                StentempP2.transform.rotation = transform.rotation;
            }
            
        }
        else
        {
            return;
        }
   }

    
    void slash()
    {
        if(canAttack == true && isFirstPlayer == true)
        {
            if(Attack_subP1 == true && Attack_mainP1 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                animscript.CanchangeAnim = false;
                //Instantiate(Dolk, transform.position, transform.rotation);
                
            }

        }
        else if(canAttack == true && isFirstPlayer==false)
        {
            if(Attack_subP2 == true && Attack_mainP2 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                animscript.CanchangeAnim = false;
                //Instantiate(Dolk, transform.position, transform.rotation);
                        
            } 
        }

    }
   


    #region Attack inputs
    void Update()
    {
       if (gameObject.tag == "Player1")
        {


            //main attack
            if(Input.GetButtonDown("Attack1_p1"))
            {
                
                if(canAttack == true)
                {
                    Attack_mainP1 = true;
                    Throw();
                    
                }
                else if(canAttack == false)
                {
                    Attack_mainP1 = false;
                } 
            }

            else if(Input.GetButtonUp("Attack1_p1"))
            {
                Attack_mainP1 = false;
                StartCoroutine(attack_cld());
                
                
            }
            //sub attack
            else if(Input.GetButtonDown("Attack2_p1"))
            {
                if(canAttack == true)
                {
                    Attack_subP1 = true;
                    slash();
                    
                }
                else if(canAttack == false)
                {
                    Attack_subP1 = false;
                }

            }
            else if(Input.GetButtonUp("Attack2_p1"))
            {
                Attack_subP1 = false;
                StartCoroutine(attack_cld());
            }
            if(Input.GetButtonDown("Defens_p1"))
            {
                Defens_mainP1 =true;
                Def();
            }

            else if(Input.GetButtonUp("Defens_p1"))
            {
                Defens_mainP1=false;  
            }

          
            
        }
        else if(gameObject.tag == "Player2")
        {
            //main attack
            if(Input.GetButtonDown("Attack1_p2"))
            {

                
                if(canAttack)
                {
                    Attack_mainP2 = true;
                    Throw();
                }
                else if(canAttack == false)
                {
                    Attack_mainP2 = false;
                }
                
            }
            else if(Input.GetButtonUp("Attack1_p2"))
            {
                Attack_mainP2 = false;
                StartCoroutine(attack_cld());
            }
            //sub attack
            if(Input.GetButtonDown("Attack2_p2"))
            {
                
                if(canAttack)
                {
                    Attack_subP2 = true;
                    slash();
                }
                else if(canAttack == false)
                {
                    Attack_subP2 = false;
                }
                
            }
            else if(Input.GetButtonUp("Attack2_p2"))
            {
                Attack_subP2 = false;
                StartCoroutine(attack_cld());
            }
             if(Input.GetButtonDown("Defens_p2"))
            {
                Defens_mainP2 =true;
                Def();
            }

            else if(Input.GetButtonUp("Defens_p2"))
            {
                Defens_mainP2=false;  
            }

            

        }
        
        
        if(Attack_mainP1 == true || Attack_subP1 == true || Attack_mainP2 == true || Attack_subP2 == true)
        {
            isAttacking = true;
        }
        else if(Attack_mainP1 == false && Attack_subP1 == false && Attack_mainP2 == false && Attack_subP2 == false)
        {
            isAttacking = false;
            //Debug.Log("Idle:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("idel"));
        }

        if(spawnpoint.rotation.y==0)
        {
            stenpos = new Vector2(spawnpoint.position.x +cordx,spawnpoint.position.y);
        }
        else if(spawnpoint.rotation.y!=0)
        {
            stenpos = new Vector2(spawnpoint.position.x -cordx,spawnpoint.position.y);
        }

        //Debug.Log("Value: " + cooldown); 
    

    
    }
    #endregion
    public IEnumerator attack_cld()
    {
        
        if(isAttacking)
        {

            canAttack = false;
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
            
            
        
 
        }

    }
    /*
    private IEnumerator Animate()
    {
        while()
        {
            Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
            
          yield return null;  
        }
    }
    */
    #region instnsiering
    void FixedUpdate()
    {
        
        
    
        if(gameObject.tag=="Player1")
        {
            Knivcount = GameObject.FindGameObjectsWithTag("kastkniv").Length;
            Dolkcount = GameObject.FindGameObjectsWithTag("dolk").Length;
            StenCount = GameObject.FindGameObjectsWithTag("sten").Length;

            if(animscript.Frameindex==ThrowAnim.Length-1 || animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            if(animscript.CurrentAnimation==ThrowAnim)
            {
                if(animscript.Frameindex ==ThrowAnim.Length-1 && Knivcount<1)
                {
                    GameObject knivtemp = Instantiate(Kastkniv, spawnpoint.position,Quaternion.identity);
                    knivtemp.transform.rotation = transform.rotation;                
                }
            }
        

        
            else if(animscript.CurrentAnimation==SlashAnim)
            {
                if(animscript.Frameindex ==SlashAnim.Length-3 && Dolkcount<1)
                {
                    Instantiate(Dolk, hand.position, hand.rotation);
                    //animscript.CanchangeAnim = true;
                }
                /*else if(animscript.Frameindex == SlashAnim.Length -1 && Dolkcount >=1)
                {
                    Destroy(Dolk);
                }
                */
            }
        }
        if(gameObject.tag=="Player2")
        {
            KnivcountP2 = GameObject.FindGameObjectsWithTag("kastknivP2").Length;
            DolkcountP2 = GameObject.FindGameObjectsWithTag("dolkP2").Length;
            StenCountP2 = GameObject.FindGameObjectsWithTag("stenP2").Length;
            if(animscript.Frameindex==ThrowAnim.Length-1 || animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            if(animscript.CurrentAnimation==ThrowAnim)
            {
                if(animscript.Frameindex ==ThrowAnim.Length-1 && KnivcountP2<1)
                {
                    GameObject knivtemp = Instantiate(KastknivP2, spawnpoint.position,Quaternion.identity);
                    knivtemp.transform.rotation = transform.rotation;
                
                }
            }
        

        
            else if(animscript.CurrentAnimation==SlashAnim)
            {
                if(animscript.Frameindex ==SlashAnim.Length-3 && DolkcountP2<1)
                {
                    Instantiate(DolkP2, hand.position, hand.rotation);
                }
                /*else if(animscript.Frameindex == SlashAnim.Length -1 && Dolkcount >=1)
                {
                    Destroy(Dolk);
                }
                */
            }
        }


        
    #endregion
        
        //StartCoroutine(Animate());
        //Debug.Log("knivar:" + Knivcount);
        
        
    }
    #endregion

}
