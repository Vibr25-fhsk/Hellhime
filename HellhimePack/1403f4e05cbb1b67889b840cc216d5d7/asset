using UnityEngine;
using System.Collections;
public class Rapier_sc : MonoBehaviour
{
    public attack attackScript;
    public CapsuleCollider2D Rapier_col;
    string parentName;

    void Awake()
    {
        parentName = transform.parent.parent.parent.parent.parent.parent.parent.name;
        if(parentName == "Player1")
        {
            
            transform.rotation = Quaternion.Euler(0, 188, 0);
        }
        else if(parentName == "Player2")
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Start()
    {
        attackScript = GameObject.FindWithTag("Player1").GetComponent<attack>() ?? GameObject.FindWithTag("Player2").GetComponent<attack>();
        Rapier_col = GetComponent<CapsuleCollider2D>();
        Rapier_col.enabled = false;
    }
    void Update()
    {
        if(attackScript.isAttacking)
        {
            Rapier_col.enabled = true;
        }
        else
        {
            Rapier_col.enabled = false;
        }
    }

}
