using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoyIndcatorScript : MonoBehaviour
{
    Image joystick1;
    Image joystick2;
    public int playerNumber;
    public Sprite Ps4P1_notConnected;
    public Sprite Ps4P1_Connected;
    public Sprite Ps4P2_notConnected;
    public Sprite Ps4P2_Connected;

    GameManeger GM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joystick1 = GameObject.Find("Joy1Indicator").GetComponent<Image>();
        joystick2 = GameObject.Find("Joy2Indicator").GetComponent<Image>();
        GM = GameObject.Find("Hella_GM").GetComponent<GameManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManeger.playerJoystickIndex[0] != -1)
        {
            joystick1.sprite = Ps4P1_Connected;
        }

        if(GameManeger.playerJoystickIndex[1] != -1)
        {
            joystick2.sprite = Ps4P2_Connected;

        }


    }
}
