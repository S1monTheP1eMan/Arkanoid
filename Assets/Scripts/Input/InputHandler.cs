using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private BallMovement _ball;

    public event UnityAction MousePressed;
    public event UnityAction MouseReleased;

    private Camera _camera;

    private Vector3 _mousePosition;
    private Vector3 _offset;

    private RaycastHit _hit;
    private Ray _ray;

    private bool _mousePressed;

    private void Awake()
    {
        _camera = Camera.main;
        _offset = new Vector3(0, 0.5f);
        _mousePressed = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            GetInput();

        if (Input.GetMouseButtonUp(0) && _ball.IsActive == false)
        {
            _ball.FindLaunchDirection();
            _ball.Enable();

            MouseReleased?.Invoke();
            _mousePressed = false;
        }
    }

    private void GetInput()
    {
        _mousePosition = Input.mousePosition;
        _ray = _camera.ScreenPointToRay(_mousePosition);

        if (Physics.Raycast(_ray, out _hit) && _hit.transform.TryGetComponent<Plane>(out Plane plane))
        {
            if (_ball.IsActive == false)
                _target.position = _hit.point + _offset;

            if (_ball.IsActive == false && _mousePressed == false)
            {
                _mousePressed = true;
                MousePressed?.Invoke();
            }
        }
    }
}