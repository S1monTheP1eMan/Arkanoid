using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
