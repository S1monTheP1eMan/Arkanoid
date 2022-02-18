using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;

    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _target;

    [SerializeField] private SpriteRenderer _arrow;

    [SerializeField] private float _scaleFactor = 10f;

    public float Length => _length;

    private BallMovement _ballMovement;

    private Vector3 _direction;
    private Vector3 _size;

    private float _length;

    private void Awake()
    {
        Disable();

        _ballMovement = _ball.GetComponent<BallMovement>();
    }

    private void Update()
    {
        if (_arrow.gameObject.activeSelf == true && _ballMovement.IsActive == false)
            SetDirection();
    }

    private void OnEnable()
    {
        _inputHandler.MousePressed += OnMousePressed;
        _inputHandler.MouseReleased += OnMouseReleased;
    }

    private void OnDisable()
    {
        _inputHandler.MousePressed -= OnMousePressed;
        _inputHandler.MouseReleased -= OnMouseReleased;
    }

    private void Enable()
    {
        _arrow.gameObject.SetActive(true);
    }

    private void Disable()
    {
        _arrow.gameObject.SetActive(false);
    }

    private void SetDirection()
    {
        _direction = _target.position - _ball.position;
        transform.rotation = Quaternion.LookRotation(_direction);

        ChangeSize(_direction);
    }

    private void ChangeSize(Vector3 direction)
    {
        _length = direction.magnitude / _scaleFactor;
        _size = new Vector3(_length, _length, _length);
        transform.localScale = _size;
    }

    private void OnMousePressed()
    {
        Enable();
    }

    private void OnMouseReleased()
    {
        Disable();
    }
}