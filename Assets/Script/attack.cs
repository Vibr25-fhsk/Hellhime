using UnityEngine;
using UnityEngine.InputSystem;
public class attack : MonoBehaviour
{
    public CapsuleCollider2D  Rapier_col;

    string parentName;

    [SerializeField]private bool isAttacking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        parentName = transform.parent.parent.parent.parent.parent.name;
        
        
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

    /*
    void FixedUpdate()
    {
       if (parentName == "Player1")
        {
            if(Input.GetKey(KeyCode.Space))
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        }
        else if(parentName == "Player2")
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
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
    }
    */

    void Update()
    {
        Debug.Log("Value: " + isAttacking);
    }

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
    
}
