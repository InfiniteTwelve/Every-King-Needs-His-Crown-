using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    [SerializeField] private Ennemy _ennemy;
    [SerializeField] private GameObject _objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _ennemy.Die();
            Destroy(_objectToDestroy, 2f);
        }
        
    }
}
