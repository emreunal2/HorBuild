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
    [SerializeField] Grid grid;
    [SerializeField] GameObject highlight;
    [SerializeField] GridData placedBuildings;

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
        placedBuildings = new GridData();
    }
    void Update()
    {
        Vector3Int activeGrid = grid.WorldToCell(Utils.GetMouseWorldPosition());
        highlight.GetComponent<Transform>().position = grid.CellToWorld(activeGrid);
        Debug.Log(activeGrid);
        ActiveBuildingInput();
        if (selectedBuildingType != null)
        {

            bool placementValidity = CheckPlacementValidity(activeGrid, selectedBuildingType);
            highlight.GetComponent<SpriteRenderer>().color = placementValidity ? Color.white : Color.red;

            if (placementValidity)
            {
                PlaceBuilding(activeGrid);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            SelectBuildingType(null);
        }
    }

    private bool CheckPlacementValidity(Vector3Int activeGrid, BuildingTypeSO selectedBuildingType)
    {
        return placedBuildings.CanPlaceObjectAt(activeGrid, selectedBuildingType.Size);        
    }

    private void PlaceBuilding(Vector3Int activeGrid)
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && ResourceManager.Instance.CanAfford(selectedBuildingType.BuildingResourceAmounts))
        {
            ResourceManager.Instance.SpendResource(selectedBuildingType.BuildingResourceAmounts);
            Instantiate(selectedBuildingType.Prefab, grid.CellToWorld(activeGrid), Quaternion.identity);
            placedBuildings.AddObjectAt(activeGrid, selectedBuildingType.Size, selectedBuildingType.Id, 0);
        }
    }

    public void SelectBuildingType(BuildingTypeSO buildingType)
    {
        selectedBuildingType = buildingType;
        OnActiveBuildingChange?.Invoke();
    }

    void ActiveBuildingInput()
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
    }

}
