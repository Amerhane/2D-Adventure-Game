using UnityEngine;

public class OnKillWinGame : MonoBehaviour
{
    public void OnDestroy()
    {
        FindFirstObjectByType<UiController>().OnPlayerWin();
    }
}
