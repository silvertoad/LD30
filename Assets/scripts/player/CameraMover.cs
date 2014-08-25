using System;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [SerializeField] float Acceleration;

    [SerializeField] float TopSpeed;

    bool isVerticalDirection = true;

    void FixedUpdate ()
    {   
        Facade.I.CurrentPosition = transform.position.y;

        MoveSpeed += (Acceleration / 1000f);
        MoveSpeed = Math.Min (MoveSpeed, TopSpeed);

        var movementValue = MoveSpeed / 1000f;
        var cameraTransform = gameObject.transform;
        if (isVerticalDirection)
            cameraTransform.position += new Vector3 (0f, movementValue);
    }

    public void ChangeDirection ()
    {
        isVerticalDirection = !isVerticalDirection;
    }

    public void OnTriggerEnter2D (Collider2D _colision)
    {
        var itemState = _colision.gameObject.GetComponent (typeof(ItemState)) as ItemState;
        if (itemState != null)
            itemState.WakeUp ();
    }

    public void OnTriggerExit2D (Collider2D _colision)
    {
        var player = _colision.gameObject.GetComponent<Player> ();
        if (player != null)
            Facade.I.Controller.StartNewGame ();
    }
}