using UnityEngine;

public class Dolkslash_attack : MonoBehaviour
{

    public GameObject Dolk;
    public GameObject DolkP2;
    public Transform hand;

    public knivkast_attack kastscript;
    public attack Attack;
    public Animationscript animscript;
    
    public Sprite[] SlashAnim;
    
    public int Dolkcount;
    public int DolkcountP2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void slash()
    {
        if(Attack.canAttack == true && Attack.isFirstPlayer == true)
        {
            if(Attack.Attack_subP1 == true && Attack.Attack_mainP1 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                animscript.CanchangeAnim = false;
                //Instantiate(Dolk, transform.position, transform.rotation);
                
            }

        }
        else if(Attack.canAttack == true && Attack.isFirstPlayer==false)
        {
            if(Attack.Attack_subP2 == true && Attack.Attack_mainP2 == false)
            {
                animscript.ChangeAnimation(SlashAnim);
                animscript.CanchangeAnim = false;
                //Instantiate(Dolk, transform.position, transform.rotation);
                        
            } 
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Player1")
        {
            Dolkcount = GameObject.FindGameObjectsWithTag("dolk").Length;
            if(animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            if(animscript.CurrentAnimation==SlashAnim)
            {
                if(animscript.Frameindex ==SlashAnim.Length-3 && Dolkcount<1)
                {
                    Instantiate(Dolk, hand.position, hand.rotation);
                    //animscript.CanchangeAnim = true;
                }
                /*else if(animscript.Frameindex == SlashAnim.Length -1 && Dolkcount >=1)
                {
                    Destroy(Dolk);
                }
                */
            }
        }
    
        if(gameObject.tag=="Player2")
        {
            
            DolkcountP2 = GameObject.FindGameObjectsWithTag("dolkP2").Length;
            if(animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            else if(animscript.CurrentAnimation==SlashAnim)
            {
                if(animscript.Frameindex ==SlashAnim.Length-3 && DolkcountP2<1)
                {
                    Instantiate(DolkP2, hand.position, hand.rotation);
                }
                /*else if(animscript.Frameindex == SlashAnim.Length -1 && Dolkcount >=1)
                {
                    Destroy(Dolk);
                }
                */
            }
        }
    }
}
