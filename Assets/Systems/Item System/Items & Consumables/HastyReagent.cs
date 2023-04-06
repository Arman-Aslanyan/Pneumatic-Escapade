using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HastyReagent : Item
{
    public override void OnPickUp()
    {
        print("Hasty Reagent has been picked up!");
        base.OnPickUp();
        //Increases firing speed by 1.5% per stack
        if (proc)
        {
            foreach (ParticleGuns weapon in Weapons)
                weapon.stats.firingSpeed /= 1.015f;
            proc = false;
        }
    }
}
