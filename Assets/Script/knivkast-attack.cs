using UnityEngine;

public class knivkast_attack : MonoBehaviour
{
    public GameObject Kastkniv;
    public GameObject KastknivP2;

    public int Knivcount;
    public int KnivcountP2;
    public Transform spawnpoint;
    public Animationscript animscript;
    public attack Attack;
    public Sprite[] ThrowAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Throw()
    {
        if(Attack.canAttack == true && Attack.isFirstPlayer == true)
        {
            
            if(Attack.Attack_mainP1 == true && Attack.Attack_subP1 == false)
            {
                animscript.ChangeAnimation(ThrowAnim);
                animscript.CanchangeAnim = false;
            }
            
            else if(Attack.Attack_mainP1 == false)
            {
                //Kast = false;
                //anim.ResetTrigger("Throw");    
            }
        }

        //Debug.Log("Throw:"+ anim.GetCurrentAnimatorStateInfo(0).IsName("Throwattack"));
        if(Attack.canAttack == true && Attack.isFirstPlayer==false)
        {
            if(Attack.Attack_mainP2 == true && Attack.Attack_subP2 == false)
            {
                //Debug.Log("Is throwing knife");
                animscript.ChangeAnimation(ThrowAnim);
                animscript.CanchangeAnim = false;
            }
            else if(Attack.Attack_mainP2 == false)
            {
                
            }
        }   
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag=="Player1")
        {
            Knivcount = GameObject.FindGameObjectsWithTag("kastkniv").Length;

            /*
            if(animscript.Frameindex==ThrowAnim.Length-1 || animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            */
            if(animscript.CurrentAnimation==ThrowAnim)
            {
                if(animscript.Frameindex ==ThrowAnim.Length-1 && Knivcount<1)
                {
                    GameObject knivtemp = Instantiate(Kastkniv, spawnpoint.position,Quaternion.identity);
                    knivtemp.transform.rotation = transform.rotation;                
                }
            }
        

        
        }
        
        if(gameObject.tag=="Player2")
        {
            KnivcountP2 = GameObject.FindGameObjectsWithTag("kastknivP2").Length;
            /*
            if(animscript.Frameindex==ThrowAnim.Length-1 || animscript.Frameindex==SlashAnim.Length-1)
            {
                animscript.CanchangeAnim = true;
            }
            */
            if(animscript.CurrentAnimation==ThrowAnim)
            {
                if(animscript.Frameindex ==ThrowAnim.Length-1 && KnivcountP2<1)
                {
                    GameObject knivtemp = Instantiate(KastknivP2, spawnpoint.position,Quaternion.identity);
                    knivtemp.transform.rotation = transform.rotation;
                
                }
            }
        } 
        
    }
}
