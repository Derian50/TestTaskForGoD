
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class Weapon : Item
{
    public weaponType type;

    public override void Use()
    {
        base.Use();

    }

    public enum weaponType { auto,semi}
}
