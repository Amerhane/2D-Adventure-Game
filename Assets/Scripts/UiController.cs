using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _coinText;

    private GameController _gameController;

    private void Start()
    {
        _gameController = 
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void UpdateCoinsCollected()
    {
        _coinText.text = _gameController.Coins.ToString();
    }
}
