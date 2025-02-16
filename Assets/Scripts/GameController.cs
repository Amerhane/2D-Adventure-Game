using UnityEngine;

public class GameController : MonoBehaviour
{
    private int _coins;

    public int Coins
    {
        get
        {
            return _coins;
        }
        private set
        {
            _coins += value;
        }
    }

    public void PickUpCoin()
    {
        Coins++;
    }
}
