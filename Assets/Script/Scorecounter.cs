using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorecounter : MonoBehaviour
{
    int wincounters;

    TMP_Text Player2wins;
    TMP_Text Player1wins;
    GameManeger GM;

    public bool Scoreupdate = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Player2wins = GameObject.Find("P2Win_num").GetComponent<TMP_Text>();
        Player1wins = GameObject.Find("P1Win_num").GetComponent<TMP_Text>();
        
        GM = GameObject.Find("Hella_GM").GetComponent<GameManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        //SceneManager.GetLastActiveScene().name =="Homescreen"

        Player1wins.text = GM.P1Wins.ToString(); 
        Player2wins.text = GM.P2Wins.ToString();
    
        
    }
}
