using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairRaycastScript : MonoBehaviour
{
    float damage = 10f;
    float range = 5f;

    public Camera mainCamera = new Camera();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LeftMouseButton();
        }
    }

    void LeftMouseButton()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            Debug.Log("Hit " + hit.transform.gameObject);

            ItemBreak item = hit.transform.GetComponent<ItemBreak>();
            if(item != null)
            {
                item.TakeDamage(damage);
            }
        }
    }
}
