using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    
    private void Awake()
    {
        ghost = transform.Find("sprite").gameObject;
        ghost.SetActive(false);
    }
    void Start()
    {
        BuildingManager.Instance.OnActiveBuildingChange += BuildingGhost_OnActiveBuildingChange;
    }

    private void BuildingGhost_OnActiveBuildingChange()
    {
        if(BuildingManager.Instance.SelectedBuildingType == null)
        {
            ghost.SetActive(false);
        }
        else
        {
            ghost.GetComponent<SpriteRenderer>().sprite = BuildingManager.Instance.SelectedBuildingType.Prefab.GetComponent<SpriteRenderer>().sprite;
            ghost.SetActive(true);
        }
    }

    void Update()
    {
        transform.position = Utils.GetMouseWorldPosition();
    }
}
