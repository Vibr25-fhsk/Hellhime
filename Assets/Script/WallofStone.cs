using UnityEngine;

public class WallofStone : MonoBehaviour
{
    //script references
    attack Attack;
    Animationscript animscript;
    knivkast_attack Knivkast;
    //
    public Sprite[] StompAnim;

    protected int StenCount;
    protected int StenCountP2;

    public GameObject Sten;
    public GameObject StenP2;
    GameObject Stentemp;
    GameObject StentempP2;
    Vector2 stenpos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Attack = GetComponent<attack>();
        Knivkast = GetComponent<knivkast_attack>();
        animscript = GetComponent<Animationscript>();
    }
    public void Def()
    {

        if(Attack.Defens_mainP1 ==true && Attack.Attack_mainP1 == false && Attack.Attack_subP1 == false)
        {
            
            animscript.ChangeAnimation(StompAnim);
            animscript.CanchangeAnim = false;
        }
                

        

        if(Attack.Defens_mainP2 ==true && Attack.Attack_mainP2 == false && Attack.Attack_subP2 == false)
        {
            
            animscript.ChangeAnimation(StompAnim);
            animscript.CanchangeAnim = false;
        }
                

    }

    // Update is called once per frame
    void Update()
    {

        if(Knivkast.spawnpoint.rotation.y==0)
        {
            stenpos = new Vector2(Knivkast.spawnpoint.position.x +Attack.cordx,Knivkast.spawnpoint.position.y);
        }
        else if(Knivkast.spawnpoint.rotation.y!=0)
        {
            stenpos = new Vector2(Knivkast.spawnpoint.position.x -Attack.cordx,Knivkast.spawnpoint.position.y);
        }
        
        if(gameObject.tag=="Player1")
        {
            StenCount = GameObject.FindGameObjectsWithTag("sten").Length;

            if(animscript.CurrentAnimation==StompAnim)
            {
                if(animscript.Frameindex ==StompAnim.Length-2 && StenCount<1)
                {
                    Stentemp = Instantiate(Sten,stenpos,Quaternion.identity);
                    Stentemp.transform.rotation = transform.rotation;
                    //animscript.CanchangeAnim = true;
                }

            }
        }
        else if(gameObject.tag=="Player2")
        {
            StenCountP2 = GameObject.FindGameObjectsWithTag("stenP2").Length;
            if(animscript.CurrentAnimation==StompAnim)
            {
                if(animscript.Frameindex ==StompAnim.Length-2 && StenCountP2<1)
                {
                    StentempP2 = Instantiate(StenP2,stenpos,Quaternion.identity);
                    StentempP2.transform.rotation = transform.rotation;
                    //animscript.CanchangeAnim = true;
                }

            }
        }
        
    
    }
}
