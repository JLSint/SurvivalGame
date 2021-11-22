using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach(string item in inventoryDictionary.Keys)
            {
                Debug.Log(item +  inventoryDictionary[item]+"x");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DroppedItem")
        {
            if (inventoryDictionary.ContainsKey(other.gameObject.GetComponent<DroppedItem>().itemName))
            {
                inventoryDictionary[other.gameObject.GetComponent<DroppedItem>().itemName]++;
                Debug.Log("Picked up " + other.gameObject.GetComponent<DroppedItem>().itemName);
            }
            else
            {
                inventoryDictionary.Add(other.gameObject.GetComponent<DroppedItem>().itemName, 1);
                Debug.Log("Picked up " + other.gameObject.GetComponent<DroppedItem>().itemName);
            }
            
            Destroy(other.gameObject);
        }
    }
}
