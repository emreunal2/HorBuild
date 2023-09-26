using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/NewBuilding")]
public class BuildingTypeSO : ScriptableObject
{
    [SerializeField] string buildingName;
    [SerializeField] GameObject prefab;
    [SerializeField] BuildingResourceAmount[] buildingResourceAmounts;
    [SerializeField] int id;
    [SerializeField] Vector2Int size = Vector2Int.one;
    [SerializeField] string buildingInfo;

    public string BuildingName { get => buildingName; set => buildingName = value; }
    public string BuildingInfo { get => buildingInfo; set => buildingInfo = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }
    public BuildingResourceAmount[] BuildingResourceAmounts { get => buildingResourceAmounts; set => buildingResourceAmounts = value; }
    public int Id { get => id; set => id = value; }
    public Vector2Int Size { get => size; set => size = value; }
}
