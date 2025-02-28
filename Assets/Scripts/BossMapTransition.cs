using Unity.Cinemachine;
using UnityEngine;

public class BossMapTransition : MapTransition
{
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private GameObject instructionsPanel;
    private GameController gameController;

    private void Start()
    {
        instructionsPanel.SetActive(false);
        boss.SetActive(false);
        gameController = FindFirstObjectByType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameController.GetCoins() >= 10)
            {
                loadMap.SetActive(true);
                collision.gameObject.transform.position =
                    playerSpawnPosition.position;
                confiner.BoundingShape2D = mapBoundary;
                unloadMap.SetActive(false);
                boss.SetActive(true);
            }
            else
            {
                instructionsPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            instructionsPanel.SetActive(false);
        }
    }
}
