using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D mapBoundary; //map to tranfer to.
    [SerializeField]
    private GameObject unloadMap; //map to unload.
    [SerializeField]
    private GameObject loadMap; //map to load;
    [SerializeField]
    private Transform playerSpawnPosition; //where to put player on new map.

    private CinemachineConfiner2D confiner;

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            loadMap.gameObject.SetActive(true);
            confiner.BoundingShape2D = mapBoundary;
            collision.gameObject.transform.position = 
                playerSpawnPosition.position;
            unloadMap.gameObject.SetActive(false);
        }
    }
}
