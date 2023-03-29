using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetFuel : Item
{
    public override void OnPickUp()
    {
        print("Jet Fuel has been picked up!");
        base.OnPickUp();
        //Increase player's dash length
        if (proc)
        {
            playerMovement.dashTime += 0.5f;
            proc = false;
        }
    }
}
