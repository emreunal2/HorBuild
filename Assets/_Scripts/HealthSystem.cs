using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamege(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

}
