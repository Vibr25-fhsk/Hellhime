using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    int Korpses;
    public int P1Wins;
    public int P2Wins;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    void Update()
    {


        Korpses = GameObject.FindGameObjectsWithTag("Dead").Length;
        if(Korpses>0)
        {
            SceneManager.LoadScene("HomeScreen");
        }
    }
}
