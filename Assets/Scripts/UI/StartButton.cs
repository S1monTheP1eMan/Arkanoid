using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private CanvasGroup _group;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnStartButtonClick);
        _inputHandler.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        _group.alpha = 0;
        _inputHandler.gameObject.SetActive(true);
    }
}
