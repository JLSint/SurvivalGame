using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBreak : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    float health;
    public float currentHealth;
    float drops;

    // Start is called before the first frame update
    void Start()
    {
        //setting some variables
        switch (this.gameObject.name)
        {
            case "RockNode":
                drops = Random.Range(2, 5);
                health = 100f;
                break;
            case "Tree":
                drops = Random.Range(3, 6);
                health = 70f;
                break;
            case "CopperNode":
                drops = Random.Range(1, 3);
                health = 145f;
                break;
            case "GoldNode":
                drops = Random.Range(1, 3);
                health = 135f;
                break;
            case "DiamondNode":
                drops = 1;
                health = 200f;
                break;
            default:
                drops = 0;
                health = 100f;
                break;
        }
        
        currentHealth = health;
    }
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
        Debug.Log("Resource broken");
        for(float i = 1; i <= drops; i++)
        {
            Instantiate<GameObject>(droppedItemPrefab, transform.position, transform.rotation);
        }
        this.gameObject.SetActive(false);
    }
   
}
