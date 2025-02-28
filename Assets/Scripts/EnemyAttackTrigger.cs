using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyController parentController;
    [SerializeField, Min(1)]
    private float attackCooldown = 1f;
    private float timeSinceAttack = 0f;
    private bool canAttack = true;

    private void Start()
    {
        parentController = GetComponentInParent<EnemyController>();
    }

    private void Update()
    {
        if (!canAttack)
        {
            timeSinceAttack += Time.deltaTime;
            
            if (timeSinceAttack >= attackCooldown)
            {
                canAttack = true;
                timeSinceAttack = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            parentController.GetAnimator().SetTrigger(AnimationStrings.attackTrigger);
            canAttack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            parentController.GetAnimator().SetTrigger(AnimationStrings.attackTrigger);
            canAttack = false;
        }
    }
}
