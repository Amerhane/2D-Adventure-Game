using UnityEngine;

public class GameController : MonoBehaviour
{
    private int coins;

    private void Start()
    {
        coins = 0;
    }

    public void PickUpCoin()
    {
        coins++;
    }

    public int GetCoins()
    {
        return coins;
    }
}
