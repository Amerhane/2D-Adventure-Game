using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject creditsPanel;

    public void OnPlayButtonPress()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnCreditsButtonPress()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
    }
}
