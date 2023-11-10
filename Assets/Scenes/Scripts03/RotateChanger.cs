using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChanger : MonoBehaviour
{
    private int _animationTime = 5;

    private int _targertXRotation = 45;
    private int _targertYRotation = 70;
    private int _targertZRotation = 90;

    private void Start()
    {
        transform.DORotate(new Vector3(_targertXRotation, _targertYRotation, _targertZRotation), _animationTime).SetLoops(-1, LoopType.Restart);
    }
}
