using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARegularScrewdriver : Item
{
    private bool InEffect = false;
    private int effectStacks = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (InEffect)
        {
            foreach (ParticleGuns weapon in Weapons)
            {
                weapon.stats.gunDamage += 0.5f;
            }
            StartCoroutine(TimeUntilNextStack());
        }
    }

    public override void OnPickUp()
    {
        print("A Reguar Screwdriver has been picked up!");
        base.OnPickUp();
        //Gain one Screw for every 10 seconds that you go without taking damage in a room. Lose all stacks on taking damage or moving
        effectStacks = 0;
        InEffect = true;
    }

    private IEnumerator TimeUntilNextStack()
    {
        InEffect = false;
        yield return new WaitForSeconds(10);
    }

    public void RemoveAllStacks()
    {
        effectStacks = 0;

    }
}