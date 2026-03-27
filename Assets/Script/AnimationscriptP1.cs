using System.Collections;
using UnityEngine;

public class Animationscript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] CurrentAnimation;
    //public bool KanbytaAnim = true;
    attack Attack;
    
    public int Frameindex = 0;
    public float frameRate = 0.15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimationLoop());

    }


    IEnumerator AnimationLoop()
    {
        while (true)
        {
            if(CurrentAnimation != null && CurrentAnimation.Length > 0)
            {
                if (Frameindex >= CurrentAnimation.Length)
                {
                    Frameindex = 0;
                }
                spriteRenderer.sprite = CurrentAnimation[Frameindex];
                Frameindex++;
                yield return new WaitForSeconds(frameRate);
            }
               
                
            yield return null;
                
        }
    }
    public void ChangeAnimation(Sprite[] changeAnim)
    {
        
        
        
        if (CurrentAnimation != changeAnim)
        {
        CurrentAnimation = changeAnim;
        Frameindex = 0;
        }
        

    }
    
}
