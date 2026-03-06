using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
public class attack : MonoBehaviour
{
    
    [SerializeField]float cooldown = 1f;

    Transform Rapier_Transform;
    public bool canAttack = true;
    Animator anim;
    [SerializeField]public bool Attack_mainP1{get; private set;}
    [SerializeField]public bool Attack_subP1{get; private set;}

    [SerializeField]public bool Attack_mainP2{get; private set;}
    [SerializeField]public bool Attack_subP2{get; private set;}
    
     [SerializeField]public bool isAttacking{get; private set;}

    
    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);

        Debug.Log(gameObject.tag);
    }

    void Awake()
    {
        
    }

    #region Attack
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
        if(Attack_mainP1 == true || Attack_subP1 == true || Attack_mainP2 == true || Attack_subP2 == true)
        {
            isAttacking = true;
        }
        else if(Attack_mainP1 == false && Attack_subP1 == false && Attack_mainP2 == false && Attack_subP2 == false)
        {
            isAttacking = false;
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
#endregion


}
