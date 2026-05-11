using UnityEngine;

public class Dolk_sc : MonoBehaviour
{
    //public Animationscript animscript;
    attack Attack;
    Dolkslash_attack Dolkslash_p1;
    Dolkslash_attack Dolkslash_p2;
    [SerializeField] float destructtime = 0.1f;
    bool Destrukt = false;
    BoxCollider2D DolkCollider;
    void Awake()
    {
        DolkCollider = GetComponent<BoxCollider2D>();
        Dolkslash_p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Dolkslash_attack>();
        Dolkslash_p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Dolkslash_attack>();
        if(gameObject.tag == "dolk")
        {
            if(Dolkslash_p1.Dolkcount>1)
            {
                Destroy(gameObject);
            }  
        }
        else if(gameObject.tag == "dolkP2")
        {
            if(Dolkslash_p2.DolkcountP2>1)
            {
                Destroy(gameObject);
            }

        }
        
        Destroy(gameObject, destructtime);
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(gameObject.tag == "dolk" && other.gameObject.tag == "Player2")
        {
            Destrukt = true;
        }
        else if(gameObject.tag == "dolkP2" && other.gameObject.tag == "Player1")
        {
            Destrukt = true;
        }
        else if(gameObject.tag != "dolk" && other.gameObject.tag != "Player2" || gameObject.tag != "dolkP2" && other.gameObject.tag != "Player1")
        {
            Destrukt = true;
        }
    }
    void Update()
    {
        if(Destrukt)
        {
            Destroy(gameObject);
        }

    }


}
