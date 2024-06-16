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
    private KeyCode _spawnProjectle = KeyCode.Space;
    private KeyCode _launch = KeyCode.W;
    private KeyCode _return = KeyCode.S;

    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(_launch))
        {
            UpdateAnchorPosition(_secondPosition);
        }

        if (Input.GetKeyUp(_return))
        {
            UpdateAnchorPosition(_firstPosition);
        }

        if (Input.GetKeyUp(_spawnProjectle))
        {
            Instantiate(_projectile);
        }
    }

    private void UpdateAnchorPosition(float newPosition)
    {
        Vector3 currentAnchor = _springJoint.anchor;
        currentAnchor.y = newPosition;
        _springJoint.anchor = currentAnchor;
    }
}
