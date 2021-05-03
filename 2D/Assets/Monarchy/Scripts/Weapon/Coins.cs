using UnityEngine;
public class Coins : Weapon
{
    [SerializeField] private int _damage;
    [SerializeField] private float _forceX;
    [SerializeField] private float _forceY;

    public float ForceX { get; private set; }
    public float ForceY { get; private set; }
    private void Awake()
    {
        Damage = _damage;
        ForceX = _forceX;
        ForceY = _forceY;
    }
}
