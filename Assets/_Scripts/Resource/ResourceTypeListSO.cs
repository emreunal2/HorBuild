using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Resource List")]
public class ResourceTypeListSO : ScriptableObject
{
    [SerializeField] List<ResourceTypeSO> list;

    public List<ResourceTypeSO> List { get => list; set => list = value; }
}
