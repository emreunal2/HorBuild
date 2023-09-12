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
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectBuildingType(buildingTypeList.BuildingTypeList[1]);
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Instantiate(selectedBuildingType.Prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

    }

    Vector3 GetMouseWorldPosition() 
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    }

    public void SelectBuildingType(BuildingTypeSO buildingType) 
    {
        selectedBuildingType = buildingType;
    }
}
