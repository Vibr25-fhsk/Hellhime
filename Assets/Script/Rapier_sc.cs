using UnityEngine;
using System.Collections;
public class Rapier_sc : MonoBehaviour
{
    [SerializeField]float cooldown = 1f;
    public attack attack_script;

    public Animator anim;

    public bool canAttack = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isThrusting",false);

    }

    public IEnumerator attack_cld()
    {
        
        if(attack_script.isAttacking)
        {

            canAttack = false;
            yield return new WaitForSeconds(cooldown);
            canAttack = true;
        
 
        }


        //GetComponent<CapsuleCollider2D>().enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
