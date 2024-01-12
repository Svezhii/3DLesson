using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BaseFlagManager))]
public class Base : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private List<Unit> _units;
    [SerializeField] private float _radarInterval;

    private BaseFlagManager _baseFlagManager;
    private List<Resource> _resources = new List<Resource>();
    private int _priceUnit = 3;
    private int _priceNewBase = 5;
    public event UnityAction ScoreChange;
    public int Score { get; private set; } = 0;

    private void Awake()
    {
        _baseFlagManager = GetComponent<BaseFlagManager>();
    }

    private void Update()
    {
        StartCoroutine(FindResources(transform.position, _radius));

        Debug.Log(_units.Count);

        foreach (var unit in _units)
        {
            if(Score >= _priceNewBase && unit.IsReady && _baseFlagManager)
            {
                Score -= _priceNewBase;
                unit.GoToFlag(_baseFlagManager.Flag);
                _units.Remove(unit);
                _baseFlagManager.SwitchFlag();
                break;
            }
            else if (_resources.Count > 0 && unit.IsReady)
            {
                unit.GoToResource(_resources[0]);
                _resources[0].IsTaken = true;
                RemoveResources();
            }
        }
    }

    private IEnumerator FindResources(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        var waitForSecond = new WaitForSeconds(_radarInterval);

        while (enabled)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent<Resource>(out Resource resource) && !_resources.Contains(resource) && resource.IsTaken == false && resource.IsRadaring == false)
                {
                    resource.IsRadaring = true;
                    _resources.Add(resource);
                }
            }

            yield return waitForSecond;
        }
    }

    public void RemoveResources()
    {
        _resources.RemoveAt(0);
    }

    public void AddScore()
    {
        Score++;
        ScoreChange?.Invoke();
    }

    public void AddUnit(Unit unit)
    {
        _units.Add(unit);
        Score -= _priceUnit;
    }

    public void NewBase(Unit unit)
    {
        _units.Add(unit);
        Score = 0;
    }
}