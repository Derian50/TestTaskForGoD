using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionToUse;
    [SerializeField] private float speed;
    [SerializeField] private GameObject weaponEquip;

    private Rigidbody2D _rb;

    private Vector2 _moveDirection;

    private GameObject _nearestEnemy;
    private float _nearestDistance = Mathf.Infinity;
    [SerializeField] private float distanceToFire = 11f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        makeWeaponVisible();
        Invoke("addFirstWeapon", 0.5f);
        
    }

    private void addFirstWeapon()
    {
        Inventory.instance.AddItem(weaponEquip.GetComponent<ItemPickUp>().item, 1);
    }

    void FixedUpdate()
    {
        _moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        _rb.velocity = _moveDirection.normalized * speed;
    }
    private void makeWeaponVisible()
    {
        transform.Find("Weapon").gameObject.GetComponent<SpriteRenderer>().sprite = weaponEquip.GetComponent<SpriteRenderer>().sprite;
    }
    public void tryFire()
    {
        Debug.Log(Inventory.instance.countOfAmmo());
        findNearestEnemy();
        if(_nearestDistance <= distanceToFire && _nearestEnemy != null && Inventory.instance.countOfAmmo() > 0)
        {
            _nearestEnemy.GetComponent<Health>().TakeDamage(weaponEquip.GetComponent<ItemPickUp>().item.weaponDamage);
            Inventory.instance.RemoveItem(Inventory.instance.getItemByName("Ammo"), 1);
        }
    }

    private void findNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        _nearestDistance = Mathf.Infinity;
        _nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < _nearestDistance)
            {
                _nearestDistance = distanceToEnemy;
                _nearestEnemy = enemy;
            }
        }

    }
}
