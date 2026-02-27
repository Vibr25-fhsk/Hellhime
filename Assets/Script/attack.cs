using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
public class attack : MonoBehaviour
{
    public CapsuleCollider2D  Rapier_col;
    [SerializeField]float cooldown = 1f;

    Transform Rapier_Transform;
    public bool canAttack = true;

    
    
    
    

    [SerializeField] public bool isAttacking { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Rapier_col = GameObject.FindGameObjectWithTag("rapier").GetComponent<CapsuleCollider2D>();
        Rapier_col.enabled = false;
        
        /*
        Rapier_col2 = GameObject.Find("rapier_sprt").GetComponent<CapsuleCollider2D>();
        Rapier_col2.enabled = false;
        */
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
            if(Input.GetButtonDown("Fire1"))
            {
                
                if(canAttack == true)
                {
                    isAttacking = true;
                    
                }
                else if(canAttack == false)
                {
                    isAttacking = false;
                } 
            }
            
            else if(Input.GetButtonUp("Fire1"))
            {
                StartCoroutine(attack_cld());
                isAttacking = false;
            }
            
        }
        else if(gameObject.tag == "Player2")
        {
            if(Input.GetButton("Fire2"))
            {
                
                if(canAttack)
                {
                    isAttacking = true;
                }
                else if(canAttack == false)
                {
                    isAttacking = false;
                }
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        if(isAttacking)
        {
            Rapier_col.enabled = true;
        }
        else
        {
            Rapier_col.enabled = false;
        }
        //Debug.Log("Value: " + isAttacking); 
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
