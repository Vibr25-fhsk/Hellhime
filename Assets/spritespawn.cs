using UnityEngine;
using UnityEngine.SceneManagement;

public class spritespawn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Hellhime")
        {
            if (spriteRenderer.enabled == false)
            {
                spriteRenderer.enabled = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Homescreen")
        {
            if (spriteRenderer.enabled == true)
            {
                spriteRenderer.enabled = false;
            }
        }
    }
}
