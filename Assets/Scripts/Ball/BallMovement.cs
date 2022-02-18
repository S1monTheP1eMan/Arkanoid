using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Transform _startDirection;
    [SerializeField] private float _speed;

    public bool IsActive => _isActive;

    private Rigidbody _rigidbody;

    private Vector3 _nextDirection;
    private Vector3 _currentDirection;

    private float _speedMultiplier = 10;

    private bool _isActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        Disable();
    }

    private void FixedUpdate()
    {
        if (_isActive)
            Move();
    }

    public void Enable()
    {
        _isActive = true;
    }

    public void Disable()
    {
        _isActive = false;
        _rigidbody.velocity = Vector3.zero;
    }

    public void FindLaunchDirection()
    {
        _currentDirection = _startDirection.position - _rigidbody.position;
        _nextDirection = _currentDirection;
    }

    private void Move()
    {
        _rigidbody.velocity = _nextDirection.normalized * _speed * _speedMultiplier * _arrow.Length * Time.fixedDeltaTime;
    }

    private void FindNextDirection(Collision collision)
    {
        _nextDirection = Vector3.Reflect(_currentDirection, collision.GetContact(0).normal);
        _currentDirection = _nextDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Border>(out Border border))
            FindNextDirection(collision);
    }
}