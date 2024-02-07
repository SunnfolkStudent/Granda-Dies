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
    public static bool canMove;

    #region -----Cached Strings-----
    
    private static readonly int Moving = Animator.StringToHash("Moving");
    private static readonly int MoveSpeedX = Animator.StringToHash("MoveSpeedX");
    private static readonly int MoveSpeedY = Animator.StringToHash("MoveSpeedY");
    private static readonly int HasFuckedGrandpa = Animator.StringToHash("hasFuckedGrandpa");
    
    #endregion
    
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
        if (canMove)
        { 
            movement = playerInput.PlayerMovement.Movement.ReadValue<Vector2>();
            rigidbody.velocity += movement * (moveSpeed * Time.deltaTime);
            AnimatePlayer();
        }
        else
        {
            movement = Vector2.zero;
            rigidbody.velocity = Vector2.zero;
            
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("happy h ubert"))
                animator.Play("Idle");
        }

            //Player interaction
        if (playerInput.PlayerMovement.Interact.triggered)
            interaction = true;
    }

    private void AnimatePlayer()
    {
        animator.SetBool(Moving, movement.magnitude > 0);
        animator.SetFloat(MoveSpeedX, movement.x);
        animator.SetFloat(MoveSpeedY, movement.y);
        return;
    }
    
    public void AnimateHappy() { animator.SetTrigger(HasFuckedGrandpa);}
    
}
