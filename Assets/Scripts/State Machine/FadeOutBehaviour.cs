using System.Runtime.CompilerServices;
using UnityEngine;

public class FadeOutBehaviour : StateMachineBehaviour
{
    [SerializeField, Min(1f)]
    private float _fadeTime = 1f;
    private float _timeElapsed;
    private SpriteRenderer _spriteRend;
    private Color _startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeElapsed = 0f;
        _spriteRend = animator.GetComponent<SpriteRenderer>();
        _startColor = _spriteRend.color;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timeElapsed += Time.deltaTime;

        float newAlpha = _startColor.a * (1 - (_timeElapsed / _fadeTime));

        _spriteRend.color = new Color(_startColor.r, _startColor.g, _startColor.b, newAlpha);

        if (_timeElapsed > _fadeTime)
        {
            animator.GetComponentInParent<EnemyController>().Kill(); //Since only enemies use this.
        }
    }
}
