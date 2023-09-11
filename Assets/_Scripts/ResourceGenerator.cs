using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] float currentTime;
    [SerializeField] ResourceTypeSO resourceType;
    [SerializeField] float amount;
    void Start()
    {
        currentTime = maxTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            ResourceManager.Instance.AddResource(resourceType, amount);
            currentTime = maxTime;
        }
    }
}
