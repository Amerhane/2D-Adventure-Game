using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;
    [SerializeField]
    private Image screenBackground;
    [SerializeField]
    private TMP_Text gameOverText;
    [SerializeField]
    private TMP_Text winText;

    private GameController gameController;

    private void Start()
    {
        screenBackground.enabled = false;
        gameOverText.enabled = false;
        winText.enabled = false;
        gameController = 
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void UpdateCoinsCollected()
    {
        coinText.text = gameController.GetCoins().ToString();
    }

    public void OnPlayerWin()
    {
        screenBackground.enabled = true;
        screenBackground.color = new Color(0f, 0f, 0f, 0f);
        winText.enabled = true;
        winText.alpha = 0f;
        StartCoroutine(FadeIn(winText));
    }

    public void OnPlayerDeath()
    {
        screenBackground.enabled = true;
        screenBackground.color = new Color(0f, 0f, 0f, 0f);
        gameOverText.enabled = true;
        gameOverText.alpha = 0f;
        StartCoroutine(FadeIn(gameOverText));
    }

    private IEnumerator FadeIn(TMP_Text textToFade)
    {
        float amount = 0f;
        while (amount <= 1)
        {
            screenBackground.color = new Color(0f, 0f, 0f, amount);
            amount += 0.1f;
            yield return new WaitForSeconds(2f / 5f);
        }

        amount = 0f;
        while (amount <= 1)
        {
            textToFade.alpha = amount;
            amount += 0.1f;
            yield return new WaitForSeconds(2f / 5f);
        }

        SceneManager.LoadScene("Camp");

        yield return null;
    }
}
