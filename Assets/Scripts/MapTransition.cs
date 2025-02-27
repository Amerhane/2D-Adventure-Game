using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField]
    protected BoxCollider2D mapBoundary; //map to tranfer to.
    [SerializeField]
    protected GameObject unloadMap; //map to unload.
    [SerializeField]
    protected GameObject loadMap; //map to load;
    [SerializeField]
    protected Transform playerSpawnPosition; //where to put player on new map.

    protected CinemachineConfiner2D confiner;

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
