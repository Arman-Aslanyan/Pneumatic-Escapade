using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : Item
{
    public override void OnPickUp()
    {
        print("Beans has been picked up!");
        base.OnPickUp();
        //Increase the player's 
        if (proc)
        {
            playerMovement.moveSpeed += 0.2f;
            proc = false;
        }
    }
}
