using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] Transform resourceTemplate;
    [SerializeField] ResourceTypeListSO resourceTypeList;
    [SerializeField] float offsize;
    [SerializeField] Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;
    [SerializeField] GameObject test;
    [SerializeField] ResourceTypeSO test2;

    public Transform resourceObject { get; private set; }

    void Awake()
    {
        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform>();
    }
    // Start is called before the first frame update
    void Start()
    {
        ResourceManager.Instance.OnAddResource += ResourceManager_OnResourceAmountChanged;
        for(int i = 0 ; i<resourceTypeList.List.Count; i++)
        {
            Transform resourceObject = Instantiate(resourceTemplate, transform);
            resourceObject.position = new Vector2(resourceTemplate.position.x + (offsize * i),resourceTemplate.position.y);
            resourceObject.gameObject.SetActive(true);
            resourceObject.Find("Image").GetComponent<Image>().sprite = resourceTypeList.List[i].sprite;
            resourceObject.Find("text").GetComponent<TextMeshProUGUI>().text = ResourceManager.Instance.ResourceAmountDictionary[resourceTypeList.List[i]].ToString();
            resourceTypeTransformDictionary[resourceTypeList.List[i]] = resourceObject;
        }
    }

    private void ResourceManager_OnResourceAmountChanged()
    {
        UpdateResourceAmount();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateResourceAmount()
    {
        foreach(ResourceTypeSO resourceType in resourceTypeList.List)
        {
            Transform resourceObject = resourceTypeTransformDictionary[resourceType];
            resourceObject.Find("text").GetComponent<TextMeshProUGUI>().text = ResourceManager.Instance.ResourceAmountDictionary[resourceType].ToString();
        }
    }

}
