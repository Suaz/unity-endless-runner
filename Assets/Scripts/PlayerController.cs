using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController characterController;

    private float movement = 0;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float jumpForce = 0;
    [SerializeField] private bool jump = false;

    private Player playerInput;
    private Player.MovementsActions movementsActions;
    private Vector3 movePlayer = new Vector3();
    private float fallVelocity;
    private bool moving = false;
    private int playerMovement;

    // Start is called before the first frame update
    [SerializeField] private float moveAhead = 0;

    public void addHealth()
    {
        moveAhead = 1;
    }


    void Start()
    {
        playerMovement = LevelController.Instance.MovementSpeed;
        playerInput = new Player();
        movementsActions = playerInput.Movements;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        movement = movementsActions.Move.ReadValue<float>();
        jump = movementsActions.Jump.ReadValue<float>() > 0;
        SetGravity();
        Jump();
        movePlayer.x = movement * playerMovement;
        if (moveAhead > 0)
        {
            if (transform.position.z < 0)
            {
                movePlayer.z = Time.deltaTime*3;
            }

            moveAhead -= Time.deltaTime;
        }

        characterController.Move(movePlayer * Time.deltaTime);
    }

    public void SetGravity()
    {
        if (characterController.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
        }

        movePlayer.y = fallVelocity;
    }

    public void Jump()
    {
        if (jump && characterController.isGrounded)
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
            // jump = false;
        }
    }
}