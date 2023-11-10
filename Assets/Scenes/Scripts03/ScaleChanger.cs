using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private int _animationTime = 2;
    private int _targetScale = 2;

    private void Start()
    {
        transform.DOScale(new Vector3(_targetScale, _targetScale, _targetScale), _animationTime).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
