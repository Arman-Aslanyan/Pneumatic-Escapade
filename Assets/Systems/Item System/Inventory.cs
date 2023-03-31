using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(PlayerMovement))]
public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 0;
    [SerializeField] private List<Item> items = new List<Item>();
    private TMP_Text ItemLog;

    //public versions of the variables for reference
    public int _capacity { get => capacity; }
    public List<Item> _items { get => items; }

    private void Start()
    {
        ItemLog = GameObject.Find("ItemLogging").GetComponent<TMP_Text>();
    }

    public void ShoutAcquiredItem(string item)
    {
        ItemLog.text += $"You acquired \"{item}\"\n";
        StartCoroutine(WaitToClearLog($"You acquired \"{item}\"\n"));
    }

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

    private IEnumerator WaitToClearLog(string line)
    {
        yield return new WaitForSeconds(3.5f);
        ItemLog.text = ItemLog.text.Remove(0, line.Length);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
            other.GetComponent<Item>().OnPickUp();
    }
}
