using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool canMove = true;
    [SerializeField] bool canJump = true;
    [SerializeField] PlayerInput playerInput;

    private InputAction interractAction;
    private InputAction movetAction;
    private InputAction jumpAction;

    private Vector2 _Move;
    private Rigidbody rb;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();

        movetAction = playerController.Instance.GetPlayerInput().actions["Movement"];
        movetAction.started += GetMovement;
        movetAction.performed += GetMovement;
        movetAction.canceled += GetMovement;

        interractAction = playerController.Instance.GetPlayerInput().actions["Interract"];
        interractAction.performed += Interraction;
        interractAction.canceled += Interraction;
    }

    void Update()
    {
        canJump = isGrounded();
        if (!canMove)
            return;
        Vector3 playerVelocity = new Vector3(_Move.x * speed, rb.velocity.y, _Move.y * speed);
    }

    #region movement
    void GetMovement(InputAction.CallbackContext ctx)
    {
        _Move = ctx.ReadValue<Vector2>();
    }

    void jump(InputAction.CallbackContext ctx)
    {
        if(!canJump)
            return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool isGrounded()
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Vector3.down);
        return Physics.Raycast(ray.origin, ray.direction, 1f);
    }
    #endregion

    #region interract
    void Interraction(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //pick up object
        }
        else if (ctx.canceled)
        {
            //if pick is not pressed
        }
    }
    #endregion


}
