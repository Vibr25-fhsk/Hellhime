using UnityEngine;
using UnityEngine.UIElements;

public class Throwing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator anim;
    Transform spawnpoint;
    attack attack_script;
    public GameObject Kastkniv;
    
    public int knifeamount;
   

   // Start is called once before the first execution of Update after the MonoBehaviour is created

   void Start()

   {

        anim =GameObject.FindWithTag("Player1").GetComponent<Animator>();

        attack_script =GameObject.FindWithTag("Player1").GetComponent<attack>();

        //attack_script =GameObject.FindWithTag("Player2").GetComponent<attack>();
        spawnpoint = GameObject.Find("spawnpunkt").GetComponent<Transform>();
        

   }



   // Update is called once per frame

   void Update()

   {
        
        /*else if(knifeamount > 0)
        {
            knifeamount=0;
        }
        */

        
        


   }
    void FixedUpdate()
    {   
        
        
    }
}
