using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.InputSystem;
public class attack : MonoBehaviour
{
    public CapsuleCollider2D  Rapier_col;

    string parentName;
    
    float cooldown;
    public Rapier_sc rapier_script;

    [SerializeField] public bool isAttacking { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        parentName = transform.parent.parent.parent.parent.parent.parent.parent.name;
        
        

        //Rapier_col = GameObject.Find("Rapier_wp").GetComponent<CapsuleCollider2D>();
        Rapier_col.enabled = false;
        
        /*
        Rapier_col2 = GameObject.Find("rapier_sprt").GetComponent<CapsuleCollider2D>();
        Rapier_col2.enabled = false;
        */
        Debug.Log(parentName);
    }

    void Awake()
    {
        if(parentName == "Player1")
        {
            
            transform.rotation = Quaternion.Euler(0, 188, 0);
        }
        else if(parentName == "Player2")
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    
    void FixedUpdate()
    {
       if (parentName == "P1")
        {
            if(Input.GetButton("Fire1"))
            {
                
                if(rapier_script.canAttack == true)
                {
                    isAttacking = true;
                    rapier_script.StartCoroutine(rapier_script.attack_cld());
                }
                else if(rapier_script.canAttack == false)
                {
                    isAttacking = false;
                }
            }
            else
            {
                isAttacking = false;
            }
        }
        else if(parentName == "P2")
        {
            if(Input.GetButton("Fire2"))
            {
                rapier_script.StartCoroutine(rapier_script.attack_cld());
                if(rapier_script.canAttack)
                {
                    isAttacking = true;
                }
                else if(rapier_script.canAttack == false)
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
        Debug.Log("Value: " + isAttacking); 
    }
    

    void Update()
    {
        
    }

/*
    public void P1_Attack(InputAction.CallbackContext context)
    {
    

        isAttacking = context.ReadValueAsButton();
        if(isAttacking)
        {
            Rapier_col.enabled = true;
        }
        else
        {
            Rapier_col.enabled = false;
        }
    }
    
    public void P2_Attack(InputAction.CallbackContext context)
    {
        isAttacking = context.ReadValueAsButton();
        if(isAttacking)
        {
            Rapier_col.enabled = true;
        }
        else
        {
            Rapier_col.enabled = false;
        }
    }
    */
    

}
