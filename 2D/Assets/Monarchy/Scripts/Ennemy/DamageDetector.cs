using UnityEngine;

public class DamageDetector : MonoBehaviour
{
    [SerializeField] private Ennemy ennemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Weapon>())
        {
            // Get the damage value from the weapon
            int damage = collision.gameObject.GetComponent<Weapon>().Damage;

            // Apply Damage
            ennemy.TakeDamage(damage);

            // Check if this ennemy should die
            if (ennemy.CheckDeath)
                ennemy.Die();

            // Destroy the coin 
            Destroy(collision.gameObject);
        }
    }
}
