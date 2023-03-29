using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeOfRa : Item
{
    public bool InEffect = false;

    public override void OnPickUp()
    {
        print("Eye of Ra has been picked up!");
        base.OnPickUp();
        //Gives the player a 2.5% chance to 'Crit' dealing double damage
        if (proc)
        {
            InEffect = true;
            proc = false;
        }
    }
}
