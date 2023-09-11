using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Resources/Create Resource")]
public class ResourceTypeSO : ScriptableObject
{
    [SerializeField] string resourceName;
    public Sprite sprite;

    public string ResourceName { get => resourceName; set => resourceName = value; }
}
