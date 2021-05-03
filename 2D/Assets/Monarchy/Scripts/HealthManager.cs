using UnityEngine;
using TMPro;
public class HealthManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private HealthBar _healthBar;

    public int CurrentHealth { get; private set; }

    private const int MAX_HEALTH = 100;
    private void Awake()
    {
        CurrentHealth = MAX_HEALTH;
        SetHealthPointText();
        _healthBar.SetMaxHealth(CurrentHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ennemy>())
        {
            int damage = collision.gameObject.GetComponent<Ennemy>().Damage;
            UpdateHealth(damage);
        } 
    }
    private void UpdateHealth(int damage)
    {
        TakeDamage(damage);
        _healthBar.SetHealth(CurrentHealth);
        SetHealthPointText();
    }
    private void TakeDamage(int damage) => CurrentHealth -= damage;

    private void SetHealthPointText() => _healthText.SetText(CurrentHealth.ToString());


}
