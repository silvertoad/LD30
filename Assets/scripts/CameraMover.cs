using System;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [SerializeField] float Acceleration;

    bool isVerticalDirection = true;

    void Update ()
    {
        MoveSpeed += (Acceleration / 1000f);
        var movementValue = MoveSpeed / 1000f;
        var cameraTransform = gameObject.transform;
        if (isVerticalDirection)
            cameraTransform.position += new Vector3 (0f, movementValue);
    }

    public void ChangeDirection ()
    {
        isVerticalDirection = !isVerticalDirection;
    }
}