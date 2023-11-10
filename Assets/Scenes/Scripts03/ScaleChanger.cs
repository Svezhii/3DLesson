using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    void Start()
    {
        transform.DOScale(new Vector3(2, 2, 2), 5).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
