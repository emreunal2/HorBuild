using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 5f;
    [SerializeField] Collider2D[] colliders;
    [SerializeField] float targetRange = 5f;
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        FindClosestEnemy(20f);
    }

    private void Update()
    {
        FindClosestEnemy(targetRange);
    }

    private void FixedUpdate()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else transform.localScale = Vector3.one;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void FindClosestEnemy(float targetMaxRadius)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);
        foreach (Collider2D collider in colliders)
        {
            
            Building building = collider.GetComponent<Building>();
            if (building != null)
            {
                if(target == null)
                {
                    target = building.transform;
                }
                else
                {
                    if(Vector3.Distance(transform.position, building.transform.position) < Vector3.Distance(transform.position, target.transform.position))
                    {
                        target = building.transform;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
}
