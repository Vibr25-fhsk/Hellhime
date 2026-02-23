using UnityEngine;
using UnityEngine.InputSystem;
public class playercontorl_sc : MonoBehaviour
{
    #region movement
    [SerializeField]private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveinput;

    

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       rb.linearVelocity = moveinput * moveSpeed; 
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }

}
