using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rigidBody;

    [SerializeField, Min (1)]
    private float moveSpeed;
    private bool isMoving = false;
    private bool isFacingRight = true;

    private Animator animator;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        if (!LockVelocity())
        {
            rigidBody.linearVelocity = new Vector2(moveInput.x * GetCurrentMoveSpeed(),
                                            moveInput.y * GetCurrentMoveSpeed());
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
        SetIsMoving(moveInput != Vector2.zero);

        if(animator.GetBool(AnimationStrings.isAlive)) //fix changing directions on death?
        {
            SetFacingDirection(moveInput);
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (this.moveInput.x > 0f && !isFacingRight)
        {
            SetIsFacingRight(true);
        }
        else if (this.moveInput.x < 0f && isFacingRight)
        {
            SetIsFacingRight(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnHit(Vector2 knockback)
    {
        if (isFacingRight)
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x - knockback.x,
                                            rigidBody.linearVelocity.y + knockback.y);
        }
        else
        {
            rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x + knockback.x,
                                            rigidBody.linearVelocity.y + knockback.y);
        }
    }

    private float GetCurrentMoveSpeed()
    {
        if (CanMove())
        {
            if (isMoving)
            {
                return moveSpeed;
            }
            else
            {
                return 0f;
            }
        }
        else
        {
            return 0f;
        }
    }

    private void SetIsMoving(bool value)
    {
        isMoving = value;
        animator.SetBool(AnimationStrings.isMoving, value);
    }

    private void SetIsFacingRight(bool value)
    {
        if (isFacingRight != value)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
        isFacingRight = value;
    }

    private bool CanMove()
    {
        return animator.GetBool(AnimationStrings.canMove);
    }

    private bool LockVelocity()
    {
        return animator.GetBool(AnimationStrings.lockVelocity);
    }
}
