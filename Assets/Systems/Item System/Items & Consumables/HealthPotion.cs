using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Consumable
{
    public int heal_LowerLim = 15;
    public int heal_UpperLim = 30;

    public override void OnPickUp()
    {
        print("Health Potion has been picked up!");
        if (stacks < maxStacks)
        {
            if (stacks == 0)
                inventory._items.Add(this);
            ++stacks;
            DestroyImmediate(gameObject);
        }
    }

    public override void TriggerEffect()
    {
        int healing = Random.Range(heal_LowerLim, heal_UpperLim + 1);
        //PlayerCombat.currentHP += healing;
        print("Healed " + healing + " hp!");
        --stacks;
        if (stacks == 0)
            inventory.RemoveAllOfType<HealthPotion>();
    }
}
