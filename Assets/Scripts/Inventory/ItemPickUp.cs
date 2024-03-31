using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] public Item item;
    [SerializeField] private int count = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Inventory.instance.AddItem(item, count);
            Destroy(gameObject);
        }
    }
}
