using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(BallMovement))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;

    private BallMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<BallMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Block>(out Block block) || collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Reset();
        }

    }

    private void Reset()
    {
        transform.position = _startPosition.position;
        _movement.Disable();
    }
}