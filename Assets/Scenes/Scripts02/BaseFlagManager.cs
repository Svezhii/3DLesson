using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFlagManager : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;

    private Base _base;

    public Flag Flag { get; private set; }
    public bool IsClickOnBase { get; private set; } = false;
    public bool HasFlag { get; private set; } = false;

    private void Awake()
    {
        _base = GetComponent<Base>();
    }

    public void SwitchFlag()
    {
        HasFlag = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            var finalPosition = hit.point;
            finalPosition.y = 23.67f;

            if (hit.collider.TryGetComponent<Base>(out Base based))
            {
                _base = based;

                IsClickOnBase = true;
            }

            if(hit.collider.GetComponent<Borders>() && IsClickOnBase && !HasFlag)
            {
                Flag = Instantiate(_flagPrefab, finalPosition, Quaternion.identity);

                IsClickOnBase = false;
                HasFlag = true;
            }

            if(hit.collider.GetComponent<Borders>() && IsClickOnBase && HasFlag)
            {
                Flag.transform.position = finalPosition;
                IsClickOnBase = false;
            }
        }
    }
}
