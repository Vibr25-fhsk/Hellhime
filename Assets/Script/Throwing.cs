using UnityEngine;

public class Throwing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   Animator anim;

   attack attack_script;

   // Start is called once before the first execution of Update after the MonoBehaviour is created

   void Start()

   {

       anim =GameObject.FindWithTag("Player1").GetComponent<Animator>();

       attack_script =GameObject.FindWithTag("Player1").GetComponent<attack>();

       attack_script =GameObject.FindWithTag("Player2").GetComponent<attack>();

   }



   // Update is called once per frame

   void Update()

   {

       if(attack_script.Attack_mainP1 == true)

       {

           anim.SetTrigger("Throw");

       }

       else if(attack_script.Attack_mainP1 == false)

       {

           anim.ResetTrigger("Throw");

       }



        if(attack_script.Attack_subP1 == true)

       {

           anim.SetTrigger("Slash");

       }

       else if(attack_script.Attack_subP1 == false)

       {

           anim.ResetTrigger("Slash");

       }

   }
}
