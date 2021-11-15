using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I live!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Picked up " + this.gameObject.name);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("Picked up " + this.gameObject.name);
        }
    }
}
