using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declare Private Variables
    private InputActions playerInput;
    private Vector2 movement;
    private Rigidbody2D rigidbody;

    //Declare Public Variables
    public float moveSpeed;
    
    //Enable input action map
    private void Awake() { playerInput = new InputActions(); }
    private void OnEnable() { playerInput.Enable(); }
    private void OnDisable() { playerInput.Disable(); }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
            //Player Movement
        movement = playerInput.PlayerMovement.Movement.ReadValue<Vector2>();
        //Debug.Log("Player Movement: " + movement);
        rigidbody.velocity += (movement * moveSpeed) / 10;

        if (playerInput.PlayerMovement.Interact.triggered)
        {
            Debug.Log("Player Interacting");
        }
    }
}
