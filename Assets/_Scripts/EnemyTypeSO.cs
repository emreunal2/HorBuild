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

    public string EnemyName { get => enemyName; set => enemyName = value; }
    public int EnemyID { get => enemyID; set => enemyID = value; }
    public float Xp { get => xp; set => xp = value; }
    public GameObject Prefab { get => prefab; set => prefab = value; }
}
