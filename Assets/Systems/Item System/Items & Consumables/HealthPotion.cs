using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumable
{
    [Range(15, 30)] public int healing;

    public override void OnPickUp()
    {
        print("Health Potion has been picked up!");
        if (stacks < maxStacks)
        {
            stacks++;
            inventory._items.Add(this);
        }
    }

    public override void TriggerEffect()
    {
        PlayerCombat.currentHP += Random.Range(15, 31); //Upperbound is exclusive
        stacks--;
    }
}
