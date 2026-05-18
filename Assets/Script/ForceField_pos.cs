using UnityEngine;

public class ForceField : MonoBehaviour
{
    public RectTransform EnterTransform;
    public RectTransform QuitTransform;
    private GameObject QuitForce;
    private GameObject EnterForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnterTransform = GameObject.Find("Enter_combat").GetComponent<RectTransform>();
        QuitTransform = GameObject.Find("Leav").GetComponent<RectTransform>();
        QuitForce = GameObject.Find("QuitForcefilde");
        EnterForce = GameObject.Find("EnterForcefilde");

        //QuitForce.transform.position = QuitTransform.rect.position;
        //EnterForce.transform.position = EnterTransform.rect.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
