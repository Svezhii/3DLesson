using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public const string Vertical = nameof(Vertical);
    public const string Horizontal = nameof(Horizontal);

    public float VerticalMove { get; private set; }
    public float HorizontalMove { get; private set; }

    private void Update()
    {
        VerticalMove = Input.GetAxis(Vertical);
        HorizontalMove = Input.GetAxis(Horizontal);
    }
}
