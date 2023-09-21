using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGrowth : MonoBehaviour
{
    [SerializeField] private float _growthSpeed;

    void Update()
    {
        transform.localScale += Vector3.one * _growthSpeed * Time.deltaTime;
    }
}
