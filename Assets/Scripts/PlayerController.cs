using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    CharacterController characterController;

    private Player playerInput;
    private Player.MovementsActions movementsActions;

    [SerializeField]
    private float movement = 0;

    private Vector3 movePlayer = new Vector3();

    [SerializeField]
    private float gravity = 9.8f;
    private float fallVelocity;

    [SerializeField]
    private float jumpForce = 0;

    [SerializeField]
    private bool jump = false;
    private bool moving = false;

    // Start is called before the first frame update
    private float currentRail = -3;

    void Start()
    {
        playerInput = new Player();
        movementsActions = playerInput.Movements;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // movePlayer = new Vector3();
        movement = movementsActions.Move.ReadValue<float>();
        jump = movementsActions.Jump.ReadValue<float>() > 0;
        // jump = movementsActions.Jump.triggered;

        SetGravity();
        Jump();
        Move();

        Debug.Log(movePlayer);
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

    public void Move()
    {
        if (movement != 0 && !moving)
        {
            StartCoroutine(Moving(0, movement > 0 ? 2 : -2));
        }
    }

    IEnumerator Moving(int start, int target)
    {
        moving = true;
        float timeElapsed = 0f;
        float duration = 1f;
        while (timeElapsed < duration)
        {
            float current = Mathf.Lerp(start, target, timeElapsed / duration);
            // Debug.Log(current);
            movePlayer.x = current;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        moving = false;
    }
}
