using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToDrop;

    public void DropOnDeath()
    {
        Instantiate(objectToDrop, this.transform.position, Quaternion.identity);
    }
}
