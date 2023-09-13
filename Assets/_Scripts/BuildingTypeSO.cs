using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/NewBuilding")]
public class BuildingTypeSO : ScriptableObject
{
    [SerializeField] string buildingName;
    [SerializeField] GameObject prefab;
    [SerializeField] BuildingResourceAmount[] buildingResourceAmounts;

    public string BuildingName { get => buildingName; set => buildingName = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }
    public BuildingResourceAmount[] BuildingResourceAmounts { get => buildingResourceAmounts; set => buildingResourceAmounts = value; }
}
