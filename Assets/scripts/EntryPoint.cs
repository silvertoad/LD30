using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] GameObject WorldContainer;

    public void Awake ()
    {
        Facade.I.Init (WorldContainer);
    }
}