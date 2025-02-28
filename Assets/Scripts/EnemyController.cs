using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private DetectionZone detection;
    private Animator animator;

    [SerializeField, Min(1)]
    private float moveSpeed;
    private bool isMoving = false;
    private bool isFacingRight = true;
    private Vector2 moveDirection;

    [SerializeField]
    private bool boss = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        detection = GetComponentInChildren<DetectionZone>();
    }

    private void Update()
    {
        if (detection.GetTarget() != null && ShouldMoveToPlayer())
        {
            MoveToPlayer();
        }
        else
        {
            SetIsMoving(false);
        }
    }

    private void FixedUpdate()
    {
        if (!LockVelocity())
        {
            rigidBody.linearVelocity = new Vector2(moveDirection.x * GetCurrentMoveSpeed(),
                moveDirection.y * GetCurrentMoveSpeed());
        }
    }

    private bool ShouldMoveToPlayer()
    {
        if (Vector2.Distance(detection.GetTarget().transform.position, this.transform.position) >= 1f)
        {
            return true;
        }

        return false;
    }

    private void MoveToPlayer()
    {
        Vector2 direction = (detection.GetTargetPosition() -
                                this.gameObject.transform.position).normalized;
        moveDirection = direction;
        SetIsMoving(true);
        SetFacingDirection(direction);
    }

    private void SetFacingDirection(Vector2 movingDirection)
    {
        if (movingDirection.x > 0f && !isFacingRight)
        {
            SetIsFacingRight(true);
        }
        else if (movingDirection.x < 0f && isFacingRight)
        {
            SetIsFacingRight(false);
        }
    }

    public void OnHit(Vector2 knockback)
    {
        if(isFacingRight)
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

    public void Kill()
    {
        if (!boss)
        {
            GetComponent<DropItemOnDeath>().DropOnDeath();
        }
        Destroy(this.gameObject);
    }

    public Animator GetAnimator()
    {
        return animator;
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
