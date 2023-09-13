using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;
    
    [SerializeField] BuildingTypeListSO buildingTypeList;
    [SerializeField] private BuildingTypeSO selectedBuildingType;

    public static BuildingManager Instance;

    public BuildingTypeSO SelectedBuildingType { get => selectedBuildingType; set => selectedBuildingType = value; }

    public event Action OnActiveBuildingChange;
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
    }
    void Start()
    {
        mainCamera = Camera.main;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectBuildingType(buildingTypeList.BuildingTypeList[0]);
            BuildsUI.Instance.UpdateSelected(buildingTypeList.BuildingTypeList[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectBuildingType(buildingTypeList.BuildingTypeList[1]);
            BuildsUI.Instance.UpdateSelected(buildingTypeList.BuildingTypeList[1]);
        }


        if (selectedBuildingType != null && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            
            Instantiate(selectedBuildingType.Prefab, Utils.GetMouseWorldPosition(), Quaternion.identity);
        }
        if(Input.GetMouseButtonDown(1))
        {
            SelectBuildingType(null);
        }

    }



    public void SelectBuildingType(BuildingTypeSO buildingType)
    {
        selectedBuildingType = buildingType;
        OnActiveBuildingChange?.Invoke();
    }

}
