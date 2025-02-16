using UnityEngine;
using UnityEngine.Events;

public class CoinPickup : MonoBehaviour
{
    public UnityEvent CollectCoin;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        CollectCoin.AddListener(
            GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>().PickUpCoin);
        CollectCoin.AddListener(
            GameObject.FindGameObjectWithTag("UiController")
            .GetComponent<UiController>().UpdateCoinsCollected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger(AnimationStrings.pickUpTrigger);
            CollectCoin.Invoke();
        }
    }
}
