using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    private GameController gameController;

    private void Start()
    {
        gameController = 
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void UpdateCoinsCollected()
    {
        coinText.text = gameController.GetCoins().ToString();
    }
}
