using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Slider healthSlider;
    private float _currentHealth;
    void Start()
    {
        _currentHealth = maxHealth;
        SetMaxHealth(maxHealth);
        SetHealth(_currentHealth);
    }
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        SetHealth(_currentHealth);
        if(_currentHealth <= 0 )
        {
            Die();
        }
    }
    private void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            GetComponent<Enemy>().DropLoot();
            Destroy(gameObject);
        }
    }
    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
