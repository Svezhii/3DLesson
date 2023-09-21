using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovementAndGrowth : MonoBehaviour
{
    private float _speed = 2;
    private float _rotationSpeed = 50f;
    private float _growthSpeed = 0.5f;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);

        transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);

        transform.localScale += Vector3.one * _growthSpeed * Time.deltaTime;
    }
}
