using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/EnemyTypeList")]
public class EnemyTypeListSO : ScriptableObject
{
    [SerializeField] List<EnemyTypeSO> list;

    public List<EnemyTypeSO> List { get => list; set => list = value; }
}
