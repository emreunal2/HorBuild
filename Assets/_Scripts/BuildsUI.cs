using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildsUI : MonoBehaviour
{
    public static BuildsUI Instance;
    [SerializeField] Transform buildTemplate;
    [SerializeField] BuildingTypeListSO buildingTypeList;
    [SerializeField] Dictionary<BuildingTypeSO, Transform> buildingTypeTransform;
    [SerializeField] float offsize;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        buildingTypeTransform = new Dictionary<BuildingTypeSO, Transform>();
    }

    void Start()
    {
        BuildingManager.Instance.OnActiveBuildingChange += BuildsUI_OnActiveBuildingChange;
        int i = 0;
        foreach (BuildingTypeSO buildingType in buildingTypeList.BuildingTypeList)
        {
            Transform buildingObject = Instantiate(buildTemplate, transform);
            buildingObject.position = new Vector2(buildTemplate.position.x + (offsize * i), buildingObject.position.y);
            buildingObject.gameObject.SetActive(true);
            buildingObject.Find("image").GetComponent<Image>().sprite = buildingTypeList.BuildingTypeList[i].Prefab.GetComponent<SpriteRenderer>().sprite;
            buildingTypeTransform[buildingType] = buildingObject;

            buildingObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SelectBuildingType(buildingType);
                UpdateSelected(buildingType);
            });
            i++;
        }
    }

    private void BuildsUI_OnActiveBuildingChange()
    {
        UpdateSelected(BuildingManager.Instance.SelectedBuildingType);
    }

    void Update()
    {

    }
    public void UpdateSelected(BuildingTypeSO selected)
    {
        ClearSelected();
        if (selected != null)
        {
            buildingTypeTransform[selected].GetComponent<Image>().color = Color.black;
        }
    }

    public void ClearSelected()
    {
        foreach (BuildingTypeSO buildingType in buildingTypeTransform.Keys)
        {
            buildingTypeTransform[buildingType].GetComponent<Image>().color = Color.white;
        }
    }
}