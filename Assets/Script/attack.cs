using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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


    
    public bool Kast = false;
    [SerializeField]float cooldown = 1f;
    //AnimatorStateInfo stateInfo;
    public Transform spawnpoint;
    public Transform hand;
    #region Weapons
    public int Knivcount;
    public int Dolkcount;
    public GameObject Kastkniv;
    public GameObject Dolk;

    public GameObject Rapier;
    #endregion
    
    public bool canAttack = true;
    Animator anim;
    [SerializeField]public bool Attack_mainP1;
    [SerializeField]public bool Attack_subP1;

    [SerializeField]public bool Attack_mainP2;
    [SerializeField]public bool Attack_subP2;
    
    public bool isAttacking{get; private set;}

    
    

    

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
        
        anim = GetComponent<Animator>();
        //anim.SetBool("isIdle", true);

        Debug.Log(gameObject.tag);
    }

    void Awake()
    {
        kast();
    }
    void Throw()
    {
        if(canAttack == true)
        {
        
            if(Attack_mainP1 == true && Attack_subP1 == false)
            {
                animscript.ChangeAnimation(ThrowAnim);
                

                //Kast = true;
                
                //Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
                //knifeamount++;
            }
            
            else if(Attack_mainP1 == false)
            {
                //Kast = false;
                //anim.ResetTrigger("Throw");    
            }

            if(Attack_mainP2 == true && Attack_subP1 == false)
            {
                animscript.ChangeAnimation(ThrowAnim);
            }



        //Debug.Log("Throw:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("Throwattack"));
        }
        
    }
    
    void slash()
    {
        if(canAttack == true)
        {
            if(Attack_subP1 == true && Attack_mainP1 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                
                //Instantiate(Dolk, transform.position, transform.rotation);
                
            }
            
            else if(Attack_subP1 == false)
            {
                //anim.ResetTrigger("Slash");
                //if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Slash"))
                //{
                 //   Destroy(Dolk);
                //}
                
            }

            if(canAttack == true)
        
            if(Attack_subP2 == true && Attack_mainP1 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                
                //Instantiate(Dolk, transform.position, transform.rotation);
                
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
                    Throw();
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
                    slash();
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
    void FixedUpdate()
    {
        Knivcount = GameObject.FindGameObjectsWithTag("kastkniv").Length;
        Dolkcount = GameObject.FindGameObjectsWithTag("dolk").Length;
        if(animscript.CurrentAnimation==ThrowAnim)
        {
            if(animscript.Frameindex ==ThrowAnim.Length-1 && Knivcount<1)
            {
                Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
            }
        }
        else if(animscript.CurrentAnimation==SlashAnim)
        {
            if(animscript.Frameindex ==SlashAnim.Length-3 && Dolkcount<1)
            {
                Instantiate(Dolk, hand.position, hand.rotation);
            }
            /*else if(animscript.Frameindex == SlashAnim.Length -1 && Dolkcount >=1)
            {
                Destroy(Dolk);
            }
            */
        }
        
        
        
        //StartCoroutine(Animate());
        Debug.Log("knivar:" + Knivcount);
        
        
    }
    void kast()
    {
        /*for(animscript.Frameindex !=ThrowAnim,)
        {
            if(animscript.Frameindex ==ThrowAnim.Length-1 && Knivcount<1)
            {
                Instantiate(Kastkniv, spawnpoint.position, spawnpoint.rotation);
            }
        }
        */
    }
    #endregion

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}
