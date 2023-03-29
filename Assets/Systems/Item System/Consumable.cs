using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public override void OnPickUp()
    {
        print("Consumable picked up!");
        base.OnPickUp();
    }

    private void Update()
    {
        if (stacks > 0 && Input.GetKeyDown(KeyCode.G))
        {
            print("Triggering consumable!");
            OnTriggerEffect();
        }
    }

    //When called, triggers the consumables effect
    public virtual void OnTriggerEffect()
    {
        print("Consumable effect triggered!");
        --stacks;
        if (stacks == 0)
            inventory.RemoveAllOfType<HealthPotion>();
    }
}
