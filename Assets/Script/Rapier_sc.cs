using UnityEngine;
using System.Collections;
public class Rapier_sc : MonoBehaviour
{
    string parentName;

    void Awake()
    {
        parentName = transform.parent.parent.parent.parent.parent.parent.parent.name;
        if(gameObject.tag == "P1")
        {
            
            transform.rotation = Quaternion.Euler(0, 188, 0);
        }
        else if(gameObject.tag == "P2")
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
