using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PauseButton : MonoBehaviour
{
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private InputHandler _inputHandler;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnPauseButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        _group.alpha = 1;
        _inputHandler.gameObject.SetActive(false);
    }
}