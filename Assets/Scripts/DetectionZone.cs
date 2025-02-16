using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private GameObject _target;
    private Vector3 _targetPosition;

    public GameObject Target
    {
        get
        {
            return _target;
        }
        private set
        {
            _target = value;
        }
    }

    public Vector3 TargetPostion
    {
        get
        {
            return _targetPosition;
        }
        private set
        {
            _targetPosition = value;
        }
    }

    private void Start()
    {
        Target = null;
    }

    private void Update()
    {
        if (Target != null)
        {
            TargetPostion = Target.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Target = null;
        }
    }
}
