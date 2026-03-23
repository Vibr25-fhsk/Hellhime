using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Projectil_sc : MonoBehaviour
{
    [SerializeField] float destructtime = 2f;

    


    Transform spawnpoint;
    
    
    
    
    Rigidbody2D rb;
    attack Attack;
    //attack Attack2; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
         
        
        spawnpoint = GameObject.Find("spawnpunkt").GetComponent<Transform>();
        
        Attack = GameObject.FindGameObjectWithTag("Player1").GetComponent<attack>();
        //Attack2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<attack>();
        if(Attack.Knivcount>1)
        {
            Destroy(gameObject);
        }
        /*
        if(Attack2.Knivcount>1)
        {
            Destroy(gameObject);
        }
        */
        
        rb = GetComponent<Rigidbody2D>();
        if(Attack.isFirstPlayer ==false)
        {
           
        }
        
        string parentname = spawnpoint.parent.tag;
        //rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
          
        Destroy(gameObject, destructtime);
        if(parentname=="Player1")
        {
            rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);   
        }
        else
        {
            rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
        }



        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player1"|| other.gameObject.tag =="Player2")
        {
            Destroy(gameObject);
        }
    }

    */
}
