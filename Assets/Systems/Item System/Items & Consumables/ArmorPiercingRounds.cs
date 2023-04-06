using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPiercingRounds : Item
{
    public override void OnPickUp()
    {
        print("Armor-Piercing Rounds has been picked up!");
        base.OnPickUp();
        //Make the player deal more damage here
        if (proc)
        {
            foreach (ParticleGuns weapon in Weapons)
                weapon.stats.gunDamage += 0.1f;
            proc = false;
        }
    }
}
