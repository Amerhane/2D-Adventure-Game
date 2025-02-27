using UnityEngine;
using UnityEngine.SceneManagement;

public class OnKillWinGame : MonoBehaviour
{
    public void OnDestroy()
    {
        SceneManager.LoadScene("Win");
    }
}
