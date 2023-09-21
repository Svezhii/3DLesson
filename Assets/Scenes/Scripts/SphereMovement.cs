using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    private float _speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
}
