using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class playercontorl_sc : MonoBehaviour
{
    public bool isFirstPlayer;

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
    }
    public void Move(InputAction.CallbackContext moveContext)
    {
        moveinput = moveContext.ReadValue<Vector2>();
    }

}
