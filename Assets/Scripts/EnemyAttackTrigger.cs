using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyController _parentController;
    [SerializeField, Min(1)]
    private float _attackCooldown = 1f;
    private float _timeSinceAttack = 0f;
    private bool _canAttack = true;

    private void Start()
    {
        _parentController = GetComponentInParent<EnemyController>();
    }

    private void Update()
    {
        if (!_canAttack)
        {
            _timeSinceAttack += Time.deltaTime;
            
            if (_timeSinceAttack >= _attackCooldown)
            {
                _canAttack = true;
                _timeSinceAttack = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _canAttack)
        {
            _parentController.Animator.SetTrigger(AnimationStrings.attackTrigger);
            _canAttack = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _canAttack)
        {
            _parentController.Animator.SetTrigger(AnimationStrings.attackTrigger);
            _canAttack = false;
        }
    }
}
