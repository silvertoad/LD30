using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;

    void Awake ()
    {
        body = GetComponent<Rigidbody2D> ();
    }

    void Update ()
    {
        var mouseClick = Input.mousePosition;
        mouseClick.z = transform.position.z - Camera.main.transform.position.z;
        var target = Camera.main.ScreenToWorldPoint (mouseClick);
        Debug.DrawLine (target, transform.position);
    }

    void FixedUpdate ()
    {
        if (Input.GetMouseButtonUp (0)) {
            var mouseClick = Input.mousePosition;
            mouseClick.z = transform.position.z - Camera.main.transform.position.z;
            var target = Camera.main.ScreenToWorldPoint (mouseClick);

            body.AddForce ((target - transform.position) * -5, ForceMode2D.Impulse);
        }
    }
}