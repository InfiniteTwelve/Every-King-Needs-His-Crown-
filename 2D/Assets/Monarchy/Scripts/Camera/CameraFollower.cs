using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _positionOffset;
    [SerializeField] private float _timeOffSet;
    private Vector3 _velocity;
   
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position + _positionOffset, ref _velocity, _timeOffSet);
    }
}
