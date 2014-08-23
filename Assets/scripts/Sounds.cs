using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour 
{
    void Update() 
    {
        if (Input.GetKeyDown("space"))
            SoundManager.SwitchTheme();

        if (Input.GetKeyDown("e"))
            SoundManager.playEffect("Sounds/PickUp", 0, 0);
        if (Input.GetKeyDown("w"))
            SoundManager.playEffect("Sounds/WalHit", 0, 0);
        if (Input.GetKeyDown("q"))
            SoundManager.playEffect("Sounds/Impuls", 0, 0);

        if (Input.GetKeyDown("r"))
            SoundManager.Mute();
    }
}
 