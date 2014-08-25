using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] Transform Direction;
    [SerializeField] Animator ImpulseAnimation;
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

        Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Direction.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - Direction.position);
    }

    void FixedUpdate ()
    {
        if (Input.GetMouseButtonUp (0)) {
            var mouseClick = Input.mousePosition;
            mouseClick.z = transform.position.z - Camera.main.transform.position.z;
            var target = Camera.main.ScreenToWorldPoint (mouseClick);
            ImpulseAnimation.SetTrigger ("impulse");
            body.AddForce ((target - transform.position) * -5, ForceMode2D.Impulse);
        }
    }

    public void Die ()
    {
        Facade.I.Controller.StartNewGame ();
    }

    public void CollectCoin (int amount)
    {

    }
}