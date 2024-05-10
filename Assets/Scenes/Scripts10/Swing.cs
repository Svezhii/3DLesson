using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Swing : MonoBehaviour
{
    private float _rightSway = 15;
    private float _leftSway = -15;
    private bool _swap = false;

    private HingeJoint _hingeJoint;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JointSpring newJoint = _hingeJoint.spring;

            newJoint.targetPosition = _swap ? _leftSway : _rightSway;

            _hingeJoint.spring = newJoint;

            _swap = !_swap;
        }
    }
}