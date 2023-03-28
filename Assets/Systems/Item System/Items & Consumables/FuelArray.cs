using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelArray : Item
{
    public override void OnPickUp()
    {
        print("Fuel Array has been picked up!");
        base.OnPickUp();
        //Reduce the player's dash cooldown
        playerMovement.dashCooldown = 3.8f;
    }
}
