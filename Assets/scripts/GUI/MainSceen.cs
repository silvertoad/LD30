using System;
using UnityEngine;

public class MainSceen : MonoBehaviour
{
    [SerializeField] UIButton StartButton;

    void Awake ()
    {
        SoundManager.play("Sounds/MenuLoop");
        StartButton.onClick += StartButtonHandler;
    }

    void StartButtonHandler ()
    {
        Facade.I.Controller.StartNewGame ();
        Destroy (gameObject);
    }
}