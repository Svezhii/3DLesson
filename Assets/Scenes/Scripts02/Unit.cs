using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Base _base;

    private Vector3 _firstPosition;
    public bool IsReady = true;
    private bool _isEnterResource = false;
    private bool _isEnterBase = false;
    private Resource _currentResource;

    private void Start()
    {
        _firstPosition = transform.position;
    }

    public void GoToResource(Resource resource)
    {
        _currentResource = resource;

        StartCoroutine(MoveToTarget(_currentResource.transform.position));
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition)
    {
        while (_isEnterResource == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            yield return null;
        }

        _currentResource.transform.parent = transform;

        while (_isEnterBase == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _base.transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _base.AddScore();
        Destroy(_currentResource.gameObject);

        while (transform.position != _firstPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _firstPosition, _speed * Time.deltaTime);

            yield return null;
        }

        _isEnterResource = false;
        _isEnterBase = false;
        IsReady = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Resource otherResource = collision.GetComponent<Resource>();

        if (otherResource != null && otherResource == _currentResource)
        {
            _isEnterResource = true;
        }

        if (collision.GetComponent<Base>())
        {
            _isEnterBase = true;
        }
    }
}
