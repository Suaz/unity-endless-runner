using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;

    private Player playerInput;
    private Player.MovementsActions movementsActions;

    [SerializeField] private float movement = 0;
    [SerializeField] private float jump = 0;
    [SerializeField] private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = new Player();
        movementsActions = playerInput.Movements;
        playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        movement = movementsActions.Move.ReadValue<float>();
        jump = movementsActions.Jump.ReadValue<float>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        if (jump > 0 && isGrounded)
        {
            isGrounded = false;
            rigidbody.AddForce(Vector3.up * 250, ForceMode.Impulse);
        }

        if (movement != 0)
        {
            rigidbody.AddForce(new Vector3(movement * 80, 0, 0), ForceMode.Impulse);
        }
    }
}
