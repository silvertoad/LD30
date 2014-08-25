using UnityEngine;

public class MapItem : MonoBehaviour
{
    [SerializeField] public ItemState Disco;
    [SerializeField] public ItemState Rock;

    ItemState currentState;

    void Awake ()
    {
        currentState = Disco == null ? Rock : Disco;
    }

    public void WakeUp ()
    {
        currentState.WakeUp ();
    }
}