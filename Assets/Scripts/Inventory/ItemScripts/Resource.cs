using UnityEngine;
[CreateAssetMenu(fileName = "Resource", menuName = "Item/Resource")]
public class Resource : Item
{
    public resourceType type;

    public override void Use()
    {
        base.Use();

        //Use Resource
        // Inventory.instance.RemoveItem(this, 1);
    }

    public enum resourceType { Something }
}

