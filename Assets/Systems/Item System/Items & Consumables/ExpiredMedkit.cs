using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpiredMedkit : Item
{
    public bool InEffect = false;

    public override void OnPickUp()
    {
        print("Expired Medkit has been picked up!");
        base.OnPickUp();
        //3 seconds after taking damage, heal 1/3rd of the damage taken. More stacks increases the healing
        if (proc)
        {
            InEffect = true;
            proc = false;
        }
    }

    public IEnumerator WaitToHeal(float damageTaken)
    {
        yield return new WaitForSeconds(3);
        PlayerCombat.Heal(damageTaken / (4 - stacks));
    }
}
