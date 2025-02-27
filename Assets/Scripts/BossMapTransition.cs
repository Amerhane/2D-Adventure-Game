using UnityEngine;

public class BossMapTransition : MapTransition
{
    [SerializeField]
    private GameObject instructionsPanel;
    private GameController gameController;

    private void Start()
    {
        instructionsPanel.SetActive(false);
        gameController = FindFirstObjectByType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameController.GetCoins() >= 10)
            {
                loadMap.gameObject.SetActive(true);
                confiner.BoundingShape2D = mapBoundary;
                collision.gameObject.transform.position =
                    playerSpawnPosition.position;
                unloadMap.gameObject.SetActive(false);
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
