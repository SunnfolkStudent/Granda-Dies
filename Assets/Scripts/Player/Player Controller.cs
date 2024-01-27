using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declare Private Variables
    public static InputActions playerInput;
    private Vector2 movement;
    private Rigidbody2D rigidbody;
    private Animator animator;
    
    //Declare Public Variables
    public float moveSpeed;
    public static bool interaction;
    public bool canMove;
    
    //Enable input action map
    private void Awake() { playerInput = new InputActions(); }
    private void OnEnable() { playerInput.Enable(); }
    private void OnDisable() { playerInput.Disable(); }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canMove = true;
    }

    private void Update()
    {
        interaction = false;
        
            //Player Movement
        movement = playerInput.PlayerMovement.Movement.ReadValue<Vector2>();
        if (canMove)
            rigidbody.velocity += (movement * moveSpeed) / 10;

            //Player interaction
        if (playerInput.PlayerMovement.Interact.triggered)
            interaction = true;
        
        AnimatePlayer();
    }

    private void AnimatePlayer()
    {
        animator.SetBool("Moving", movement.magnitude > 0);
        animator.SetFloat("MoveSpeedX", movement.x);
        animator.SetFloat("MoveSpeedY", movement.y);
        return;
    }
    
}
