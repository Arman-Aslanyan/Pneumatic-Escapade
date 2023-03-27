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
            GetComponent<SpriteRenderer>().forceRenderingOff = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    public override void OnTriggerEffect()
    {
        int healing = Random.Range(heal_LowerLim, heal_UpperLim + 1);
        print(PlayerCombat.currentHP);
        //PlayerCombat.currentHP += healing;
        print("Healed " + healing + " hp!");
        base.OnTriggerEffect();
    }
}
