using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(1)]
    private float movementSpeed;

    private Rigidbody2D rb2D;
    private Vector2 movementInput;

    private Animator animator;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        rb2D.linearVelocity = movementInput * movementSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("isWalking", true);

        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
        }

        movementInput = context.ReadValue<Vector2>();

        if (movementInput.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }
}
