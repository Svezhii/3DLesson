using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int _animationTime = 2;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.DOColor(Color.red, _animationTime).SetLoops(-1, LoopType.Yoyo);
    }
}
