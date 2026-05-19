using System;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    int Korpses;
    public int P1Wins = 0;
    public int P2Wins = 0;
    

    

    void Awake()
    {
         
        DontDestroyOnLoad(gameObject);
    }
    /*
    public void WincunterP1(int P1wins)
    {
        Player1wins.text =(Convert.ToInt32(Player1wins.text)+1).ToString(); 
    }
    public void WincunterP2(int P2wins)
    {
        Player2wins.text =(Convert.ToInt32(Player2wins.text)+1).ToString();
    }
    */
    

    
    void Update()
    {
        Korpses = GameObject.FindGameObjectsWithTag("Dead").Length;
        Debug.Log(Korpses);
        
        
        
        if(Korpses>0)
        {
            SceneManager.LoadScene("Homescreen");
        }
        
    }
}
