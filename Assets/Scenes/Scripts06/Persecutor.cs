using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Persecutor : MonoBehaviour
{
    [SerializeField] PlayerMover _playerCC;
    [SerializeField] private float _speed;
    [SerializeField] private float stoppingDistance = 1f;

    private Transform _transform;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Chase();
    }

    private void Chase()
    {
        Vector3 direction = (_playerCC.transform.position - _transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(_transform.position, _playerCC.transform.position);

        if (distanceToPlayer > stoppingDistance)
        {
            _rigidbody.MovePosition(_rigidbody.position + direction * _speed * Time.deltaTime);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
