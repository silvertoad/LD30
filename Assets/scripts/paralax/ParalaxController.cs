using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField] float Acceleration;
    ScrollScript[] scrolls;

    void Start ()
    {
        scrolls = GetComponentsInChildren<ScrollScript> ();
    }

    void Update ()
    {
        foreach (var scroll in scrolls) {
            scroll.speed += scroll.DefaultSpeed * Acceleration / 1000f;
            scroll.Move ();
        }
    }
}