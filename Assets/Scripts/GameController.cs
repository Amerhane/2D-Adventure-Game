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
        AddCoin();
    }

    public int GetCoins()
    {
        return coins;
    }

    private void AddCoin()
    {
        coins++;
    }
}
