using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvigoratingElixir : Item
{
    public bool InEffect = false;

    public override void OnPickUp()
    {
        print("Invigorating Elixir has been picked up!");
        base.OnPickUp();
        //Increases the potency of healing potions by 1.5% for every stack
        if (proc)
        {
            InEffect = true;
            proc = false;
        }
    }
}