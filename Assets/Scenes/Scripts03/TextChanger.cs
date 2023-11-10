using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextChanger : MonoBehaviour
{
    private Text _text;
    private int _animationTime = 2;

    private void Start()
    {
        _text = GetComponent<Text>();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText("� ������� �����", _animationTime));
        sequence.Append(_text.DOText(", ������� �����", _animationTime).SetRelative());
        sequence.Append(_text.DOText("������ ������ � ���������", _animationTime, true, ScrambleMode.All));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
