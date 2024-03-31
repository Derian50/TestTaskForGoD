
using UnityEngine;


// BASE ITEM
public class Item : ScriptableObject
{
    public string itemName;

    public int price;

    public bool Stackable;

    public Sprite itemIcon;

    public int weaponDamage;
    public virtual void Use()
    {
        //Use item
    }
}
