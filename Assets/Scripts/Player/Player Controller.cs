using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Declare Private Variables
    private InputActions moveInput;
    private Vector2 movement;
    private Rigidbody2D rigidbody;

    //Declare Public Variables
    public float moveSpeed;
    
    //Enable input action map
    private void Awake() { moveInput = new InputActions(); }
    private void OnEnable() { moveInput.Enable(); }
    private void OnDisable() { moveInput.Disable(); }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = moveInput.PlayerMovement.Movement.ReadValue<Vector2>();
        Debug.Log("Player Movement: " + movement);
        rigidbody.velocity += (movement * moveSpeed) / 10;
    }
}
