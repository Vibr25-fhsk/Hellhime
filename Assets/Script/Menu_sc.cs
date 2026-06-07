using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_sc : MonoBehaviour
{
    private GameManeger DM;

    void Awake()
    {
        DM = GameObject.Find("Hella_GM").GetComponent<GameManeger>();
    }
    public void Enter_hellhime()
    {
        SceneManager.LoadScene("Hellhime");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Dplay1()
    {
        DM.cam.targetDisplay = 0;
    }
    public void Dplay2()
    {
        DM.cam.targetDisplay = 1;
    }
        
    

}
