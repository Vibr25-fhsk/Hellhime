using UnityEngine;
using UnityEngine.SceneManagement;
public class campscript : MonoBehaviour
{
    public Camera cam;
    float defoultScreenHight = 1440f;
    float defoultFOV = 53f;
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
        if(SceneManager.GetActiveScene().name == "Menue")
        {
            defoultScreenHight = 1440f;
            defoultFOV = 50f;
            if(cam != null)
            {
                cam.fieldOfView = defoultFOV * (Screen.height / defoultScreenHight);
            }
        }

        if(SceneManager.GetActiveScene().name=="Hellhime")
        {
            defoultScreenHight = 1440f;
            defoultFOV = 50f;
            if(cam != null)
            {
                cam.fieldOfView = defoultFOV * (Screen.height / defoultScreenHight);
            }
        }
    }
}
