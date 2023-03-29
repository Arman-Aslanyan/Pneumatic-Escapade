using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARegularScrewdriver : Item
{
    private bool InEffect = false;
    private int effectStacks = 0;
    private Coroutine coroutine;
    private float time = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (InEffect)
        {
            foreach (ParticleGuns weapon in Weapons)
            {
                weapon.stats.gunDamage += 0.5f * stacks;
            }
            ++effectStacks;
            InEffect = false;
            coroutine = StartCoroutine(TimeUntilNextStack());
        }

        if (playerMovement.rb.velocity == Vector2.zero)
            time += Time.deltaTime;
        if (time >= 3f) RemoveAllStacks();
    }

    public override void OnPickUp()
    {
        print("A Reguar Screwdriver has been picked up!");
        base.OnPickUp();
        //Gain one Screw for every 10 seconds that you go without taking damage in a room. Lose all stacks on taking damage or moving
        //more stacks increases the damage gain from each Screw
        if (proc)
        {
            effectStacks = 0;
            InEffect = true;
            proc = false;
        }
    }

    private IEnumerator TimeUntilNextStack()
    {
        yield return new WaitForSeconds(10);
        InEffect = true;
    }

    public void RemoveAllStacks()
    {
        //Avoids an unnecesarry error
        if (coroutine != null)
            StopCoroutine(coroutine);
        for (int i = 0; i < effectStacks; i++)
        {
            foreach (ParticleGuns weapon in Weapons)
            {
                weapon.stats.gunDamage -= 0.5f;
            }
        }
        effectStacks = 0;
        time = 0;
    }
}
