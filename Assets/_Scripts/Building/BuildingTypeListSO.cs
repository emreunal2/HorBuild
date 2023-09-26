using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject
{
    [SerializeField] List<BuildingTypeSO> buildingTypeList;

    public List<BuildingTypeSO> BuildingTypeList { get => buildingTypeList; set => buildingTypeList = value; }
}
