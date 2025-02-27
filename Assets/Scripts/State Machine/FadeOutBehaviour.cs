using UnityEngine;

public class FadeOutBehaviour : StateMachineBehaviour
{
    [SerializeField, Min(1f)]
    private float fadeTime = 1f;
    private float timeElapsed;
    private SpriteRenderer spriteRend;
    private Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed = 0f;
        spriteRend = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRend.color;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed += Time.deltaTime;

        float newAlpha = startColor.a * (1 - (timeElapsed / fadeTime));

        spriteRend.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if (timeElapsed > fadeTime)
        {
            animator.GetComponentInParent<EnemyController>().Kill(); //Since only enemies use this.
        }
    }
}
