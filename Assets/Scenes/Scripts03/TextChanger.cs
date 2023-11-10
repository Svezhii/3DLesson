using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextChanger : MonoBehaviour
{
    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText("я заменил текст", 2));
        sequence.Append(_text.DOText(", добавим текст", 2).SetRelative());
        sequence.Append(_text.DOText("Ёффект замены с перебором", 2, true, ScrambleMode.All));

        sequence.SetLoops(-1, LoopType.Restart);
    }
}
