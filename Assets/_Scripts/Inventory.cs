using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, int> inventoryDictionary = new Dictionary<string, int>();
    public GameObject inventoryScreen;
    public GameObject inventoryText;
    public static bool gameIsPaused;

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
            if (!gameIsPaused)
            {
                inventoryScreen.SetActive(true);
                gameIsPaused = true;
                foreach (string item in inventoryDictionary.Keys)
                {
                    inventoryText.GetComponent<Text>().text += inventoryDictionary[item] + "x " + item + "\n";
                    Debug.Log(item + inventoryDictionary[item] + "x");
                }
                Time.timeScale = 0f;
            }
            else
            {
                inventoryScreen.SetActive(false);
                gameIsPaused = false;
                inventoryText.GetComponent<Text>().text = "";
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
