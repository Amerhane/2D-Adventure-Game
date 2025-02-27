using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private DetectionZone _detection;
    private Animator _animator;

    [SerializeField, Min(1)]
    private float _moveSpeed;
    private bool _isMoving = false;
    private bool _isFacingRight = true;
    private Vector2 _moveDirection;
    
    public Animator Animator
    {
        get
        {
            return _animator;
        }
    }

    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving)
                {
                    return _moveSpeed;
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
    }

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            _animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return _animator.GetBool(AnimationStrings.canMove);
        }
    }

    public Vector2 MoveDirection
    {
        get
        {
            return _moveDirection;
        }
        private set
        {
            _moveDirection = value;
        }
    }

    public bool LockVelocity
    {
        get
        {
            return _animator.GetBool(AnimationStrings.lockVelocity);
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _detection = GetComponentInChildren<DetectionZone>();
    }

    private void Update()
    {
        if (_detection.GetTarget() != null && ShouldMoveToPlayer())
        {
            MoveToPlayer();
        }
        else
        {
            IsMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (!LockVelocity)
        {
            _rigidbody.linearVelocity = new Vector2(MoveDirection.x * CurrentMoveSpeed,
                MoveDirection.y * CurrentMoveSpeed);
        }
    }

    private bool ShouldMoveToPlayer()
    {
        if (Vector2.Distance(_detection.GetTarget().transform.position, this.transform.position) >= 1f)
        {
            return true;
        }

        return false;
    }

    private void MoveToPlayer()
    {
        Vector2 direction = (_detection.TargetPostion -
                                this.gameObject.transform.position).normalized;
        MoveDirection = direction;
        IsMoving = true;
        SetFacingDirection(direction);
    }

    private void SetFacingDirection(Vector2 movingDirection)
    {
        if (movingDirection.x > 0f && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (movingDirection.x < 0f && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnHit(Vector2 knockback)
    {
        if(IsFacingRight)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x - knockback.x,
                                            _rigidbody.linearVelocity.y + knockback.y);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x + knockback.x,
                                            _rigidbody.linearVelocity.y + knockback.y);
        }
    }

    public void Kill()
    {
        GetComponent<DropItemOnDeath>().DropOnDeath();

        Destroy(this.gameObject);
    }
}
