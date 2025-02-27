using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition;

    public GameObject Target
    {
        get
        {
            return target;
        }
        private set
        {
            target = value;
        }
    }

    public Vector3 TargetPostion
    {
        get
        {
            return targetPosition;
        }
        private set
        {
            targetPosition = value;
        }
    }

    private void Start()
    {
        target = null;
    }

    private void Update()
    {
        if (target != null)
        {
            targetPosition = target.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetTarget(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }

    public GameObject GetTarget()
    {
        return target;
    }

    private void SetTarget(GameObject target)
    {
        this.target = target;
    }
}
