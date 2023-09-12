using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildsUI : MonoBehaviour
{
    [SerializeField] Transform buildTemplate;
    [SerializeField] BuildingTypeListSO buildingTypeList;
    [SerializeField] Dictionary<BuildingTypeSO, Transform> buildingTypeTransform;
    [SerializeField] float offsize;
    // Start is called before the first frame update
    private void Awake()
    {
        buildingTypeTransform = new Dictionary<BuildingTypeSO, Transform>();
    }

    void Start()
    {
        int i = 0;
        foreach(BuildingTypeSO buildingType in buildingTypeList.BuildingTypeList)
        {
            Transform buildingObject = Instantiate(buildTemplate, transform);
            buildingObject.position = new Vector2(buildTemplate.position.x + (offsize * i), buildingObject.position.y);
            buildingObject.gameObject.SetActive(true);
            buildingObject.Find("image").GetComponent<Image>().sprite = buildingTypeList.BuildingTypeList[i].Prefab.GetComponent<SpriteRenderer>().sprite;
            buildingTypeTransform[buildingType] = buildingObject;

            buildingObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SelectBuildingType(buildingType);
            });
            i++;
        }
    }

    void Update()
    {
        
    }

    
}
