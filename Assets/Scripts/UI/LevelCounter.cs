using TMPro;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] private BlocksContainer _blocksContainer;

    private TMP_Text _counter;

    private int _levelNuber = 1;

    private void Awake()
    {
        _counter = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _blocksContainer.BlocksDestroyed += OnBlocksDestroyed;
    }

    private void OnDisable()
    {
        _blocksContainer.BlocksDestroyed -= OnBlocksDestroyed;
    }

    private void OnBlocksDestroyed()
    { 
        _levelNuber++;
        _counter.text = _levelNuber.ToString();
    }
}
