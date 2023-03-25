using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public override void OnPickUp()
    {
        print("Consumable picked up!");
        if (stacks < maxStacks)
        {
            stacks++;
            inventory._items.Add(this);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            print("Triggering consumable!");
            TriggerEffect();
        }
    }

    //When called, triggers the consumables effect
    public virtual void TriggerEffect()
    {
        print("Consumable effect triggered!");
        stacks--;
        inventory._items.Remove(this);
    }
}
