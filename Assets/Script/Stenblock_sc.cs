using System.Linq;
using UnityEngine;

public class Stenblock_sc : MonoBehaviour
{
    [SerializeField]protected float Decay = 1f;

    void Start()
    {
        
    }
    void Awake()
    {
        //gameObject.tag="Defense";
        Destroy(gameObject,Decay);
    }

}
