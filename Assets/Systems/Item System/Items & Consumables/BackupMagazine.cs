using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupMagazine : Item
{
    public override void OnPickUp()
    {
        print("Back-Up Magazine has been picked up!");
        base.OnPickUp();
        if (proc)
        {
            foreach (ParticleGuns weapon in Weapons)
                weapon.stats.ammoMax = (int)(weapon.stats.ammoMax * 1.025f);
            proc = false;
        }
    }
}
