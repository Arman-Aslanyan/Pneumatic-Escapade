using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSteel : Item
{
    public override void OnPickUp()
    {
        print("SoulSteel has been picked up!");
        base.OnPickUp();
        //Buffs players maxHP
        if (proc)
        {
            PlayerCombat.maxHP += 5;
            proc = false;
        }
    }
}
