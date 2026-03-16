using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Projectil_sc : MonoBehaviour
{
    [SerializeField] float destructtime = 2f;

    


    Transform spawnpoint;
    Rigidbody2D rb;
    attack Attack;    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
        spawnpoint = GameObject.Find("spawnpunkt").GetComponent<Transform>();
        Attack = GameObject.FindGameObjectWithTag("Player1").GetComponent<attack>();
        if(Attack.knivcount>1)
        {
            Destroy(gameObject);
        }
        
        rb = GetComponent<Rigidbody2D>();
        //rb.linearVelocity = spawnpoint.rotation.eulerAngles * 10f;
        rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
        
        
        Destroy(gameObject, destructtime);
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
