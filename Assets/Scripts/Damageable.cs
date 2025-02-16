using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private byte _maxHealth;
    private byte _health;
    private bool _isAlive;
    private bool _isInvincible;

    private Animator _animator;
    private float _timeSinceHit = 0;
    private float _invincibilityTime = 0.25f;

    public byte MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    public byte Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            _animator.SetBool(AnimationStrings.isAlive, value);
        }
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _health = _maxHealth;
        _isAlive = true;
    }

    public void Hit(Vector2 knockback)
    {
        if (IsAlive && !_isInvincible)
        {
            Health--;
            _isInvincible = true;
        }
    }

    public void Update()
    {
        if (_isInvincible)
        {
            if (_timeSinceHit > _invincibilityTime)
            {
                _isInvincible = false;
                _timeSinceHit = 0;
            }

            _timeSinceHit += Time.deltaTime;
        }
    }
}
