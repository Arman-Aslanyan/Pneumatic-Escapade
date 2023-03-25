using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //How many stacks of the item there is, and the maximum #
    public int stacks = 0;
    public int maxStacks = 1;

    //Reference variables for the Items to use
    [HideInInspector] public static WeaponHolder weaponHolder;
    [HideInInspector] public static ParticleGuns[] Weapons;
    [HideInInspector] public static Combat PlayerCombat;
    [HideInInspector] public static Inventory inventory;

    private void OnEnable()
    {
        PlayerCombat = FindObjectOfType<PlayerMovement>().combat;
        inventory = FindObjectOfType<Inventory>();
        /*if (weaponHolder == null)
        {
            weaponHolder = FindObjectOfType<WeaponHolder>();
            Weapons = weaponHolder.GetComponentsInChildren<ParticleGuns>();
            PlayerCombat = FindObjectOfType<PlayerMovement>().combat;
            inventory = PlayerCombat.GetComponent<Inventory>();
        }*/

    }

    //The item's effect (if not a consumable) will go off here
    public virtual void OnPickUp()
    {
        //print("Item has been picked up");
        /*for (int i = 0; i < Weapons.Length; i++)
        {
            print(Weapons[i].name);
        }*/
        if (stacks < maxStacks)
        {
            if (stacks == 0)
                inventory._items.Add(this);
            ++stacks;
            //Disable the rendering and collider. Then after usage, destroy the item (if consumable)
            //Destroy(gameObject, 0);
        }
    }
}
