using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Vector2 knockback = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>(); // could use interface?

        if (damageable != null)
        {
            damageable.Hit(knockback);
        }
    }
}
