using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();
    public GameObject inventoryScreen;
    public GameObject inventoryItem;
    public static bool inventoryOpen;
    float itemsInInventory;

    // Start is called before the first frame update
    void Start()
    {
        inventoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!inventoryOpen)
            {
                inventoryScreen.SetActive(true);
                inventoryOpen = true;
                Time.timeScale = 0f;
            }
            else
            {
                inventoryScreen.SetActive(false);
                inventoryOpen = false;
                Time.timeScale = 1f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DroppedItem")
        {
            if (inventoryDictionary.ContainsKey(other.gameObject.GetComponent<DroppedItem>().itemName))
            {
                if (itemsInInventory == 0)
                {
                    Instantiate<GameObject>(inventoryItem, new Vector2(354.87f, 136.5543f), transform.rotation);
                    itemsInInventory++;
                }
                else
                {
                    Instantiate<GameObject>(inventoryItem, new Vector2(354.87f, 136.5543f - 27f*itemsInInventory), transform.rotation);
                }
                
                inventoryDictionary[other.gameObject.GetComponent<DroppedItem>().itemName]++;
                inventoryItem.GetComponent<Text>().text += other.gameObject.GetComponent<DroppedItem>().itemName +  inventoryDictionary[other.gameObject.GetComponent<DroppedItem>().itemName] + "x";
                Debug.Log("Picked up " + other.gameObject.GetComponent<DroppedItem>().itemName);
            }
            else
            {
                inventoryItem.GetComponent<Text>().text += other.gameObject.GetComponent<DroppedItem>().itemName;
                inventoryDictionary.Add(other.gameObject.GetComponent<DroppedItem>().itemName, 1);
                Debug.Log("Picked up " + other.gameObject.GetComponent<DroppedItem>().itemName);
            }
            
            Destroy(other.gameObject);
        }
    }
}
