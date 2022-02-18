using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    public event UnityAction Destroyed;

    private void OnDisable()
    {
        Destroyed?.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Ball>(out Ball ball))
        {
            gameObject.SetActive(false);
        }
    }
}