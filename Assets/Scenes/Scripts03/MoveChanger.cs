using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveChanger : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveX(7, 5).SetLoops(-1, LoopType.Yoyo);
    }
}
