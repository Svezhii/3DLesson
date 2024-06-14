using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringJoint))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private float _firstPosition = 2;
    private float _secondPosition = -10;

    private SpringJoint _springJoint;

    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            Vector3 currentAnchor = _springJoint.anchor;

            currentAnchor.y = _secondPosition;

            _springJoint.anchor = currentAnchor;
        }
        
        if(Input.GetKeyUp(KeyCode.S))
        {
            Vector3 currentAnchor = _springJoint.anchor;

            currentAnchor.y = _firstPosition;

            _springJoint.anchor = currentAnchor;

        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(_projectile);
        }
    }
}
