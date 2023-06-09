using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarOfJelly : Item
{
    public override void OnPickUp()
    {
        print("Jar of Blood has been picked up!");
        base.OnPickUp();
        //Increase players Reload time
        if (proc)
        {
            foreach (ParticleGuns weapon in Weapons)
                weapon.stats.reloadTime /= 1.005f;
            proc = false;
        }
    }
}
