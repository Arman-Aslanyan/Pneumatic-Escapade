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
}
