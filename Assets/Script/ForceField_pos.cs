using UnityEngine;

public class ForceField : MonoBehaviour
{
    public Transform EnterTransform;
    public Transform QuitTransform;
    private GameObject QuitForce;
    private GameObject EnterForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnterTransform = GameObject.Find("Enter_combat").GetComponent<Transform>();
        QuitTransform = GameObject.Find("Leav").GetComponent<Transform>();
        QuitForce = GameObject.Find("QuitForcefilde");
        EnterForce = GameObject.Find("EnterForcefilde");

        QuitForce.transform.position = QuitTransform.transform.position;
        EnterForce.transform.position= EnterTransform.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
