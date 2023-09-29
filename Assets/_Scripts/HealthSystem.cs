using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamege(10);
        }
    }

    public void TakeDamege(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            IDestroyable destroyable = gameObject.GetComponent<IDestroyable>();
            destroyable.DestroyObject();
        }
    }

}
