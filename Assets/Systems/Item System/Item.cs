using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //How many stacks of the item there is, and the maximum #
    public int stacks = 0;
    public int maxStacks = 1;

    //Reference variables for the Items to use
    public WeaponHolder weaponHolder;
    public ParticleGuns[] Weapons;
    public Combat PlayerCombat;
    public Inventory inventory;

    private void Start()
    {
        PlayerCombat = FindObjectOfType<PlayerMovement>().combat;
        inventory = FindObjectOfType<Inventory>();
        if (weaponHolder == null)
        {
            weaponHolder = FindObjectOfType<WeaponHolder>();
            Weapons = weaponHolder.GetComponentsInChildren<ParticleGuns>();
            PlayerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>();
            inventory = FindObjectOfType<Inventory>();
        }
    }

    //The item's effect (if not a consumable) will go off here
    public virtual void OnPickUp()
    {
        //print("Item has been picked up");
        if (stacks < maxStacks)
        {
            if (stacks == 0)
                inventory._items.Add(this);
            ++stacks;
            GetComponent<SpriteRenderer>().forceRenderingOff = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
