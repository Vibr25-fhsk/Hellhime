using System;
using System.Linq;
using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    int Korpses;
    public int P1Wins = 0;
    public int P2Wins = 0;
    public static int[] playerJoystickIndex = new int[] { -1, -1 };
    public int joyIndex;
    float Delay = 1f;  
    

    

    void Awake()
    {
        /*
        Input.GetJoystickNames()[0].ToList();
        Debug.Log(Input.GetJoystickNames()[0].ToList());
        */
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
        //Debug.Log(Korpses);
        // Scanna joystick 1-8
        for (int joy = 1; joy <= 8; joy++)
        {
            for (int btn = 0; btn <= 19; btn++)
            {
                if (Input.GetKeyDown("joystick " + joy + " button " + btn))
                {
                    AssignController(joy);
                }
            }
        }
        
        
        
    }
    public void CorpseCollector()
    {
        Korpses = GameObject.FindGameObjectsWithTag("Dead").Length;
        if(Korpses>0)
        {
            StartCoroutine(LoadDelay());
        }
    }
    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene("Homescreen");
        
    }
    
    void AssignController(int joyIndex)
    {
        for (int p = 0; p < 2; p++)
        {
            // Redan tilldelad?
            if (playerJoystickIndex[p] == joyIndex) return;
            // Ledig plats – tilldela
            if (playerJoystickIndex[p] == -1)
            {
                playerJoystickIndex[p] = joyIndex;
                Debug.Log($"Spelare {p + 1} tilldelad joystick {joyIndex}");
                return;
            }

        }
    }
    
}
