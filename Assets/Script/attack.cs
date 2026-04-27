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

    
    public float cordx {get; private set;} =0.5f;
    
    public bool Kast = false;
    [SerializeField]float cooldown = 1f;
    //AnimatorStateInfo stateInfo;
    public Transform spawnpoint;
    public Transform hand;
    #region Weapons
    public GameObject Rapier;

    public knivkast_attack Knivkast;
    public Dolkslash_attack Dolkslash;
    #endregion
    
    #region misc
    WallofStone RaiseRock;


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
        RaiseRock = GetComponent<WallofStone>();
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
    
    

    #region Attack inputs
    void Update()
    {
       if (gameObject.tag == "Player1")
        {
            if(Attack_mainP1 == true || Attack_subP1 == true || Defens_mainP1 == true)
            {
                isAttacking = true;
            }
            else if(Attack_mainP2 == false && Attack_subP2 == false && Defens_mainP2 == false)
            {
                isAttacking = false;
                
            }


            //main attack
            if(Input.GetButtonDown("Attack1_p1"))
            {
                
                if(canAttack == true)
                {
                    Attack_mainP1 = true;
                    Knivkast.Throw();
                    
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
                    Dolkslash.slash();
                    
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
                RaiseRock.Def();
                StartCoroutine(attack_cld());
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
                    Knivkast.Throw();
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
                    Dolkslash.slash();
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
                RaiseRock.Def();
                
            }

            else if(Input.GetButtonUp("Defens_p2"))
            {
                Defens_mainP2=false;
                StartCoroutine(attack_cld()); 
            }

            

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
            if(animscript.Frameindex==Knivkast.ThrowAnim.Length-1 || animscript.Frameindex==Dolkslash.SlashAnim.Length-1 || animscript.Frameindex==RaiseRock.StompAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
        }
        if(gameObject.tag=="Player2")
        {
            if(animscript.Frameindex==Knivkast.ThrowAnim.Length-1 || animscript.Frameindex==Dolkslash.SlashAnim.Length-1 || animscript.Frameindex==RaiseRock.StompAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
        }


        
    #endregion
        
        //StartCoroutine(Animate());
        //Debug.Log("knivar:" + Knivcount);
        
        
    }
    #endregion

}
