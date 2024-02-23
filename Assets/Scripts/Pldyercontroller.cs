using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Pldyercontroller : MonoBehaviour
{
    public float walkspeed = 5f;
    Vector2 moveInput;
    Rigidbody2D rb;

    public bool Ismoving { get; private set; }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkspeed, moveInput.y*walkspeed);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Ismoving = moveInput != Vector2.zero;
    }
}
