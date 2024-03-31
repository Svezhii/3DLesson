using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _value;
    private float _delay = 0.5f;
    private int _numerator = 0;
    private bool _isActive = false;

    private void Start()
    {
        StartCoroutine(Scorer());
    }

    private void Update()
    {
        Debug.Log(_value);

        if(Input.GetMouseButtonDown(0))
        {
            SwitchNumerator();
        }
    }

    private IEnumerator Scorer()
    {
        var waitForSecond = new WaitForSeconds(_delay);

        while (enabled)
        {
            _value += _numerator;

            yield return waitForSecond;
        }
    }

    private void SwitchNumerator()
    {
        _isActive = !_isActive;
        _numerator = _isActive ? 1 : 0;
    }
}
