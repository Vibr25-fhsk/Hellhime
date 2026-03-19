using UnityEngine;

public class Dolk_sc : MonoBehaviour
{
    //public Animationscript animscript;
    attack Attack;
    [SerializeField] float destructtime = 0.1f;
    void Awake()
    {
        Attack = GameObject.FindGameObjectWithTag("Player1").GetComponent<attack>();
        if(Attack.Dolkcount>1)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, destructtime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player1"|| other.gameObject.tag =="Player2")
        {
            Destroy(gameObject);
        }
    }


}
