using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Vector2 _moveInput;
    private Rigidbody2D _rigidbody;

    [SerializeField, Min (1)]
    private float _moveSpeed;
    private bool _isMoving = false;
    private bool _isFacingRight = true;

    private Animator _animator;

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

    private void FixedUpdate()
    {
        if (!LockVelocity)
        {
            _rigidbody.linearVelocity = new Vector2(_moveInput.x * CurrentMoveSpeed,
                                            _moveInput.y * CurrentMoveSpeed);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        
        IsMoving = _moveInput != Vector2.zero;

        if(_animator.GetBool(AnimationStrings.isAlive)) //fix changing directions on death?
            SetFacingDirection(_moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (_moveInput.x > 0f && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (_moveInput.x < 0f && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnHit(Vector2 knockback)
    {
        if (IsFacingRight)
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
}
