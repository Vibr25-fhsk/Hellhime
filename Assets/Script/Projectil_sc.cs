using System.Collections;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Projectil_sc : MonoBehaviour
{
    [SerializeField] float destructtime = 2f;

    
    public bool left;
    public float delay = 0.25f;
    protected bool canPlaySound = true;
    Transform spawnpoint;
    #region Audio
    private AudioSource audiosource;
    public AudioClip KnifeClash;

    #endregion
    Rigidbody2D rb;
    attack Attack;
    
    knivkast_attack kastscript_p1;
    knivkast_attack kastscript_p2;
    
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audiosource = GetComponent<AudioSource>(); 
        
        spawnpoint = GameObject.Find("spawnpunkt").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        string parentname = spawnpoint.parent.tag;
        
        //Attack = GameObject.FindGameObjectWithTag("Player1").GetComponent<attack>();
        kastscript_p1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<knivkast_attack>();
        kastscript_p2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<knivkast_attack>();
        Destroy(gameObject, destructtime);
        
        
        if(gameObject.tag=="kastkniv")
        {
            if(kastscript_p1.Knivcount>1)
            {
                Destroy(gameObject);
            }
        }
        else if(gameObject.tag=="kastknivP2")
        {
            if(kastscript_p2.KnivcountP2>1)
            {
                Destroy(gameObject);
            }
        }
        if(transform.rotation.y==0)
        {
            rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);   
        }
        else
        {
            rb.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
        }

    }
    void Playknifeclash()
    {
        if(audiosource!=null && KnifeClash!=null)
        {
            audiosource.PlayOneShot(KnifeClash);  
        }
    }
    
    public IEnumerator DestroyAfterDelay()
    {
        if(canPlaySound)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
        yield return null;
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("kastkniv") || other.gameObject.CompareTag("kastknivP2"))
        {
            Playknifeclash();
            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    
}
