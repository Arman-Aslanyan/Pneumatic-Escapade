using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollItem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    [SerializeField] private List<Item> Common_Items = new List<Item>();
    [SerializeField] private List<Item> Elite_Items = new List<Item>();
    [SerializeField] private List<Item> Legendary_Items = new List<Item>();
    [SerializeField] private List<Item> Mythical_Items = new List<Item>();

    //Percentages to roll each rarity, following values are default vals
    [Range(0, 1)] public float common_Roll = 0.45f;
    [Range(0, 1)] public float elite_Roll = 0.35f;
    [Range(0, 1)] public float legendary_Roll = 0.125f;
    [Range(0, 1)] public float mythical_Roll = 0.075f;

    private Vector3 playerPos;
    private Inventory inventory;

    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<Item>().rarity == Rarity.Common)
                Common_Items.Add(items[i].GetComponent<Item>());
            else if (items[i].GetComponent<Item>().rarity == Rarity.Elite)
                Elite_Items.Add(items[i].GetComponent<Item>());
            else if (items[i].GetComponent<Item>().rarity == Rarity.Legendary)
                Legendary_Items.Add(items[i].GetComponent<Item>());
            else if (items[i].GetComponent<Item>().rarity == Rarity.Mythical)
                Mythical_Items.Add(items[i].GetComponent<Item>());
            else Debug.LogError("ERROR WHEN FINDING ITEMS OF RARITY, INDEX = " + i);
        }

        playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        //Follow the player
        transform.position = playerPos;

        //Debug purposes
        if (Input.GetKeyDown(KeyCode.J))
            Gamble();
    }

    public void Gamble()
    {
        print("gambling");
        float rand = Random.Range(0f, 1f);

        if (rand >= 1 - mythical_Roll)
        {
            print("Mythical");
            int randInt = Random.Range(0, Mythical_Items.Count);
            Mythical_Items[randInt].OnPickUp();
        }
        else if (rand >= 1 - legendary_Roll)
        {
            print("Legendary");
            int randInt = Random.Range(0, Legendary_Items.Count);
            Legendary_Items[randInt].OnPickUp();
        }
        else if (rand >= 1 - elite_Roll)
        {
            print("Elite");
            int randInt = Random.Range(0, Legendary_Items.Count);
            Elite_Items[randInt].OnPickUp();
        }
        else// if (rand >= 1 - common_Roll)
        {
            print("Common");
            int randInt = Random.Range(0, Common_Items.Count);
            Common_Items[0].OnPickUp();
        }
    }
}
