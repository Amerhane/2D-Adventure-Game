using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeBaseState : State
{
    [SerializeField]
    private float duration;

    protected Animator animator;
    protected bool shouldCombo;
    protected byte attackIndex;

}
