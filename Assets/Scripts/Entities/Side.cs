using System;
using UnityEngine;

public class Side : MonoBehaviour
{
    private RectTransform _rectTransform;
    private int _minionsInstantiateCount;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public RectTransform GetRectTransform() => _rectTransform;
    public int GetMinionInstantiateCount() => _minionsInstantiateCount;
    public void AddMinion()
    {
        _minionsInstantiateCount++;
    }
}
