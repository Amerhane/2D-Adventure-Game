using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    [SerializeField, Min(1)]
    private float _moveSpeed;

    public enum WalkingDirection { Left, Right}

    private WalkingDirection _walkDirection;
    private Vector2 _walkDirectionVector;

    public WalkingDirection WalkDirection
    {
        get
        {
            return _walkDirection;
        }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale =
                    new Vector2(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y);

                if (value == WalkingDirection.Right)
                {

                }
            }
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.linearVelocity =
            new Vector2();
    }
}
