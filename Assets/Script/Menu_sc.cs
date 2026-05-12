using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_sc : MonoBehaviour
{
    public void Enter_hellhime()
    {
        SceneManager.LoadScene("Hellhime");
    }

    public void Quit()
    {
        Application.Quit();
    }

        
    

}
