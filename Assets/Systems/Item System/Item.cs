using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //How many stacks of the item there is, and the maximum #
    public int stacks = 0;
    public int maxStacks = 1;

    //Reference variables for the Items to use
    internal static WeaponHolder weaponHolder;
    internal static ParticleGuns[] Weapons;
    internal static Combat PlayerCombat;
    internal static Inventory inventory;

    private void OnEnable()
    {
        if (weaponHolder == null)
        {
            weaponHolder = FindObjectOfType<WeaponHolder>();
            Weapons = weaponHolder.GetComponentsInChildren<ParticleGuns>();
            PlayerCombat = FindObjectOfType<PlayerMovement>().combat;
            inventory = PlayerCombat.GetComponent<Inventory>();
        }
    }

    //The item's effect (if not a consumable) will go off here
    public virtual void OnPickUp()
    {
        print("Item has been picked up");
        for (int i = 0; i < Weapons.Length; i++)
        {
            print(Weapons[i].name);
        }
        if (stacks < maxStacks)
        {
            stacks++;
            inventory._items.Add(this);
        }
    }
}
