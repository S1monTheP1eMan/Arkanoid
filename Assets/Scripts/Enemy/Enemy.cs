using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private BlocksContainer _blocksContainer;

    [SerializeField] private Transform _target;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _speedStep = 0.2f;

    private Vector3 _position;

    private void FixedUpdate()
    {
        MoveTowardsTarget();
    }

    private void OnEnable()
    {
        _blocksContainer.BlocksDestroyed += OnBlocksDestroyed;
    }

    private void OnDisable()
    {
        _blocksContainer.BlocksDestroyed -= OnBlocksDestroyed;
    }

    private void MoveTowardsTarget()
    {
        _position = new Vector3(_target.position.x , transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, _position, _speed * Time.fixedDeltaTime);
    }

    private void OnBlocksDestroyed()
    {
        _speed += _speedStep;
    }
}
