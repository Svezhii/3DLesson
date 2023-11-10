using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveChanger : MonoBehaviour
{
    private int _animationTime = 5;
    private int _targetPosition = 7;

    private void Start()
    {
        transform.DOMoveX(_targetPosition, _animationTime).SetLoops(-1, LoopType.Yoyo);
    }
}
