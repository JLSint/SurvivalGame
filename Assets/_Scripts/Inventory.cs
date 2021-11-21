using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> inventoryList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        inventoryList.Add("Nothing");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach(string item in inventoryList)
            {
                Debug.Log(item);
            }
        }
    }
}
