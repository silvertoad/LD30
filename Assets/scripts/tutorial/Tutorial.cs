using System;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Trigger completeTutorTrigger;

    void Awake ()
    {
        completeTutorTrigger.OnTrigger += CompleteTutorialHandler;
    }

    void CompleteTutorialHandler ()
    {
        Facade.I.IsTutorialComplete = true;
        Destroy (gameObject);
    }
}