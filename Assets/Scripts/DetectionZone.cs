using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private GameObject target;
    private Vector3 targetPosition;

    private void Start()
    {
        target = null;
        targetPosition = Vector3.zero;
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

    public Vector3 GetTargetPosition()
    {
        return target.transform.position;
    }
}
