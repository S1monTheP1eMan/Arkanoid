using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlocksContainer : MonoBehaviour
{
    [SerializeField] private List<Block> _blocks;

    public event UnityAction BlocksDestroyed;

    private int _blockCount = 0;

    private void OnEnable()
    {
        for (int i = 0; i < _blocks.Count; i++)
            _blocks[i].Destroyed += OnBlockDestroyed;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _blocks.Count; i++)
            _blocks[i].Destroyed -= OnBlockDestroyed;
    }

    private void OnBlockDestroyed()
    {
        _blockCount++;

        if (_blockCount == _blocks.Count)
        {
            BlocksDestroyed?.Invoke();

            StartReset();
        }
    }

    private void StartReset()
    {
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return null;

        for (int i = 0; i < _blocks.Count; i++)
            _blocks[i].gameObject.SetActive(true);

        _blockCount = 0;
    }
}
