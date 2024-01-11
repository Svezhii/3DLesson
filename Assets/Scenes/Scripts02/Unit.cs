using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Base _base;
    [SerializeField] private Base _basePrefab;

    private Vector3 _firstPosition;
    public bool IsReady = true;
    private bool _isEnterResource = false;
    private bool _isEnterFlag = false;
    private bool _isEnterBase = false;
    private Resource _currentResource;
    private Flag _currentFlag;
    private float positionThreshold = 0.9f;

    private void Start()
    {
        _firstPosition = transform.position;
    }

    public void GoToResource(Resource resource)
    {
        _currentResource = resource;

        StartCoroutine(MoveToResource(resource.transform.position));
    }

    public void GoToFlag(Flag flag)
    {
        _currentFlag = flag;

        StartCoroutine(MoveToFlag(flag.transform.position));
    }

    public void SetBase(Base based)
    {
        _base = based;
    }

    private IEnumerator MoveToFlag(Vector3 targetPosition)
    {
        while (_isEnterFlag == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            yield return null;
        }

        _base = Instantiate(_basePrefab, targetPosition, Quaternion.identity);
        _base.NewBase(this);
        _firstPosition = targetPosition;
        IsReady = true;
        _isEnterFlag = false;
        Destroy(_currentFlag.gameObject);
    }

    private IEnumerator MoveToResource(Vector3 targetPosition)
    {
        while (_isEnterResource == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

            yield return null;
        }

        _isEnterBase = false;
        _currentResource.transform.parent = transform;

        while (_isEnterBase == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _base.transform.position, _speed * Time.deltaTime);

            yield return null;
        }

        _base.AddScore();
        Destroy(_currentResource.gameObject);

        while (Vector3.Distance(transform.position, _firstPosition) > positionThreshold)
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

        if (collision.GetComponent<Flag>())
        {
            _isEnterFlag = true;
        }

        if (collision.GetComponent<Base>())
        {
            _isEnterBase = true;
        }
    }
}
