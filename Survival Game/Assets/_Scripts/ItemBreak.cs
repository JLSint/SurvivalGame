using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBreak : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    float health = 100f;
    public float currentHealth;

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("block broken");
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
