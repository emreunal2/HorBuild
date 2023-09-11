using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] Dictionary<ResourceTypeSO, float> resourceAmountDictionary;
    [SerializeField] ResourceTypeListSO resourceTypeList;
    public static ResourceManager Instance;
    public event Action OnAddResource;

    public Dictionary<ResourceTypeSO, float> ResourceAmountDictionary { get => resourceAmountDictionary; set => resourceAmountDictionary = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, float>();

        foreach (ResourceTypeSO resourceType in resourceTypeList.List)
        {
            resourceAmountDictionary[resourceType] = 0;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(ResourceTypeSO resourceType, float amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        OnAddResource?.Invoke();
    }

    public float GetResource(ResourceTypeSO resourceType)
    {
        return resourceAmountDictionary[resourceType];
    }
}
