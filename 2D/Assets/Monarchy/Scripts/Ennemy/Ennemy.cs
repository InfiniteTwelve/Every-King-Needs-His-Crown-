using UnityEngine;

public class Ennemy : MonoBehaviour
{    
    [SerializeField] private int _damage;
    [SerializeField] private int _maxHealth;
    private Animator _animator;

    public int Damage { get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        Damage = _damage;
        CurrentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damageTaken) => CurrentHealth -= damageTaken;

    public void Die()
    {
        // precaution
        CurrentHealth = 0;
        _animator.SetBool("Die", true);
        Destroy(this.gameObject, 2f);
    }

    public bool CheckDeath => CurrentHealth <= 0;
}
