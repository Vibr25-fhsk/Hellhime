using UnityEngine;

public class Dolk_sc : MonoBehaviour
{
    //public Animationscript animscript;
    attack Attack;
    Dolkslash_attack Dolkslash;
    [SerializeField] float destructtime = 0.1f;
    void Awake()
    {
        
        Dolkslash = GameObject.FindGameObjectWithTag("Player1").GetComponent<Dolkslash_attack>();
        if(gameObject.tag == "dolk")
        {
            if(Dolkslash.Dolkcount>1)
            {
                Destroy(gameObject);
            }  
        }
        else if(gameObject.tag == "dolkP2")
        {
            if(Dolkslash.DolkcountP2>1)
            {
                Destroy(gameObject);
            }

        }
        
        Destroy(gameObject, destructtime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.tag == "dolk" && other.gameObject.tag == "Player2")
        {
            Destroy(gameObject);
        }
        else if(gameObject.tag == "dolkP2" && other.gameObject.tag == "Player1")
        {
            Destroy(gameObject);
        }
    }


}
