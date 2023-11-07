using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Unit[] _units;

    private int _score = 0;
    private List<Resource> _resources = new List<Resource>();

    private void Update()
    {
        FindResources(transform.position, _radius);

        foreach(var unit in _units)
        {
            if (_resources.Count > 0 && unit.IsReady)
            {
                unit.GoToResource(_resources[0]);
                _resources[0].IsTaken = true;
                RemoveResources();
                unit.IsReady = false;
            }
        }
    }

    private void FindResources(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.TryGetComponent<Resource>(out Resource resource) && !_resources.Contains(resource) && resource.IsTaken == false)
            {
                _resources.Add(resource);
            }
        }
    }

    public void RemoveResources()
    {
        _score++;
        _resources.RemoveAt(0);
    }
}