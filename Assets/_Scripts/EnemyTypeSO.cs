using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/NewEnemy")]
public class EnemyTypeSO : ScriptableObject
{
    [SerializeField] string enemyName;    
    [SerializeField] int enemyID;
    [SerializeField] float xp;
    [SerializeField] GameObject prefab;
}
