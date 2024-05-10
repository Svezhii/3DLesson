using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private bool _hasCollided = true;
    private int _minLifeTime = 2;
    private int _maxLifeTime = 6;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<CubeInstantiator>(out CubeInstantiator cubeInstantiate) && _hasCollided)
        {
            _hasCollided = false;
            GetComponent<Renderer>().material.color = Random.ColorHSV();
            StartCoroutine(DestroyCube());
        }
    }

    private IEnumerator DestroyCube()
    {
        int a = Random.Range(_minLifeTime, _maxLifeTime);
        var waitForSecond = new WaitForSeconds(a);

        while (enabled)
        {
            yield return waitForSecond;

            Destroy(gameObject);
        }
    }

}
