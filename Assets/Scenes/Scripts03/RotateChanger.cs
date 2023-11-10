using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChanger : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(45, 70, 90), 5).SetLoops(-1, LoopType.Restart);
    }
}
