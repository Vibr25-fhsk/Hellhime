using UnityEditor.Callbacks;
using UnityEngine;

public class Projectil_sc : MonoBehaviour
{
    Transform spawnpoint;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spawnpoint = GameObject.Find("spawnpunkt").GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        //rb.linearVelocity = spawnpoint.rotation.eulerAngles * 10f;
        rb.AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
