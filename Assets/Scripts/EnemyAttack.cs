using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyController _parentController;

    private void Start()
    {
        _parentController = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _parentController.Animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }
}
