using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<Vector2> damageableHit;
    public UnityEvent onHitUI;

    [SerializeField]
    private float _maxHealth;
    private float _health;
    private bool _isAlive;
    private bool _isInvincible;
    private float _healthAsPercent;

    [SerializeField]
    private GameObject _healthBar;
    private Animator _animator;
    private float _timeSinceHit = 0;
    [SerializeField]
    private float _invincibilityTime = 1f;

    public float MaxHealth
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

    public float Health
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
        _healthAsPercent = 1f;
    }

    public void Hit(Vector2 knockback)
    {
        if (IsAlive && !_isInvincible)
        {
            Health--;
            _healthAsPercent = _health / _maxHealth;
            UpdateHealthBar();
            _isInvincible = true;
            _animator.SetTrigger(AnimationStrings.hitTrigger);
            damageableHit?.Invoke(knockback);
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

    private void UpdateHealthBar()
    {
        _healthBar.transform.localScale = new Vector3(_healthAsPercent, 1f, 1f);
    }
}
