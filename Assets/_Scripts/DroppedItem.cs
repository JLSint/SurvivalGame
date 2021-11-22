using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public string itemName;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I live!");
        switch (this.gameObject.name)
        {
            case "RockShard(Clone)":
                itemName = "Rock Shard";
                break;
            case "Wood(Clone)":
                itemName = "Bark";
                break;
            case "CopperOre(Clone)":
                itemName = "Copper Ore";
                break;
            case "GoldOre(Clone)":
                itemName = "Gold Ore";
                break;
            case "Diamond(Clone)":
                itemName = "Diamond";
                break;
            default:
                itemName = "null";
                break;
        }
    }
}
