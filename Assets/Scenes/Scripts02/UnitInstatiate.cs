using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Base))]
public class UnitInstatiate : MonoBehaviour
{
    [SerializeField] private Unit _prefab;

    private Base _base;
    private BaseFlagManager _baseFlagManager;

    private void Awake()
    {
        _base = GetComponent<Base>();
        _baseFlagManager = GetComponent<BaseFlagManager>();
    }

    private void OnEnable()
    {
        _base.ScoreChange += SpawnUnit;
    }

    private void OnDisable()
    {
        _base.ScoreChange -= SpawnUnit;
    }

    private void SpawnUnit()
    {
        if(_base.Score >= 3 && !_baseFlagManager.HasFlag)
        {
            Unit unit = Instantiate(_prefab, _base.transform.position, Quaternion.identity);
            unit.SetBase(_base);
            _base.AddUnit(unit);
        }
    }
}
