using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if (hit.collider.TryGetComponent<CubeSpawner>(out CubeSpawner cube))
            {
                cube.GenerateCubes();
                Destroy(cube.gameObject);
            }
        }
    }
}
