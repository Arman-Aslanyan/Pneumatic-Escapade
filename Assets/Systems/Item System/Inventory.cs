using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 0;
    [SerializeField] private List<Item> items = new List<Item>();

    //public versions of the variables for reference
    public int _capacity { get => capacity; }
    public List<Item> _items { get => items; }

    //Only removes one of the type for some reason, but that also works out
    public void RemoveAllOfType<T>()
    {
        foreach (Item curItem in items)
        {
            if (curItem.GetType() == typeof(T))
            {
                items.Remove(curItem);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Item>().OnPickUp();
    }
}
