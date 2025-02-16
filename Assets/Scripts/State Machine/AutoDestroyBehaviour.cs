using UnityEngine;

public class AutoDestroyBehaviour : StateMachineBehaviour
{
    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        Destroy(animator.gameObject.transform.parent.gameObject);
    }
}
