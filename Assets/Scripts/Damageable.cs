using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<Vector2> damageableHit;
    public UnityEvent onHitUI;

    [SerializeField]
    private float maxHealth;
    private float health;
    private bool isAlive;
    private bool isInvincible;
    private float healthAsPercent;

    [SerializeField]
    private GameObject healthBar;
    private Animator animator;
    private float timeSinceHit = 0;
    [SerializeField]
    private float invincibilityTime = 1f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        health = maxHealth;
        isAlive = true;
        healthAsPercent = 1f;
    }

    public void Hit(Vector2 knockback)
    {
        if (isAlive && !isInvincible)
        {
            TakeDamage();
            healthAsPercent = health / maxHealth;
            UpdateHealthBar();
            isInvincible = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
            damageableHit?.Invoke(knockback);
        }
    }

    public void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;
            }

            timeSinceHit += Time.deltaTime;
        }
    }

    private void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Kill();
        }
    }

    private void Kill()
    {
        isAlive = false;
        animator.SetBool(AnimationStrings.isAlive, false);
    }

    private void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(healthAsPercent, 1f, 1f);
    }
}
