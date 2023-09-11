using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] BuildingTypeListSO buildingTypeList;
    [SerializeField] private BuildingTypeSO selectedBuildingType;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectBuildingType(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectBuildingType(1);
        }
        if (Input.GetMouseButtonDown(0))
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

    void SelectBuildingType(int index) 
    {
        selectedBuildingType = buildingTypeList.BuildingTypeList[index];
    }
}
