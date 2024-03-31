using UnityEngine;
[CreateAssetMenu(fileName = "Consumable", menuName = "Item/Consumable")]
public class Consumable : Item
{
    public consumableType typeOfConsumable;

    public override void Use()
    {
        base.Use();
        Inventory.instance.RemoveItem(this, 1);
    }

    public enum consumableType { Ammo }
   
}
