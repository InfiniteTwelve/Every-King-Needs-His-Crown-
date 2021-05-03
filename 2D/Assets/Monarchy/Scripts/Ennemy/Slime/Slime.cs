using UnityEngine;
public class Slime : Ennemy
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] Transform[] _wayPoints;

    private Transform _target;
    private int _destinationPoint;
    private SpriteRenderer _graphics;
    

    private void Start()
    {
       
        _graphics = GetComponent<SpriteRenderer>();
        _target = _wayPoints[0];
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (CheckDeath == false)
        {
            Vector3 dir = _target.position - transform.position;
            transform.Translate(dir.normalized * _moveSpeed * Time.deltaTime, Space.World);

            // If ennemy is almost to destination
            if (Vector3.Distance(transform.position, _target.position) < 0.3f)
            {
                _destinationPoint = (_destinationPoint + 1) % _wayPoints.Length;
                _target = _wayPoints[_destinationPoint];
                _graphics.flipX = !_graphics.flipX;
            }
        }
    }
}
