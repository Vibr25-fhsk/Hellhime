using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class playercontorl_sc : MonoBehaviour
{
    public bool isFirstPlayer;

    /*
    public Sprite[] IdleAnim;
    public Sprite[] RunAnim;
    public Animationscript animscript;
    */
    public attack attackscript;

    #region movement
    [SerializeField]private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveinput;
    float horizontalMovement;
    #endregion

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        //animscript = GetComponent<Animationscript>();
    }
    void Awake()
    {


        
    }
    // Update is called once per frame
    void Update()
    {
        if(isFirstPlayer == true)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal_P2");
        }
    
        rb.linearVelocity = new Vector2(horizontalMovement * moveSpeed, rb.linearVelocity.y);
        /* 
        if (rb.linearVelocity.x <= 0.5 && attackscript.isAttacking == false)
        {
            
            animscript.ChangeAnimation(IdleAnim);
        }
        */

    }


    public void Move(InputAction.CallbackContext moveContext)
    {
        moveinput = moveContext.ReadValue<Vector2>();
    }

}
