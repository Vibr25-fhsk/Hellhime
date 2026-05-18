using UnityEngine;

public class Campscript : MonoBehaviour
{
    public Camera cam;
    float defoultScreenHight = 1080f;
    float defoultFOV = 54f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cam = Camera.main;
        OnScreenRezized();
    }

    // Update is called once per frame
    void OnScreenRezized()
    {
        cam.fieldOfView = defoultFOV * (Screen.height / defoultScreenHight);
    }
}
