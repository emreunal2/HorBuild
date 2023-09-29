using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float range;
    [SerializeField] float shootDelay;
    [SerializeField] GameObject arrow;

    private float shootTimer;

    private void Awake()
    {
        shootTimer = shootDelay;
    }
    void Start()
    {
        
    }
 

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer < 0)
        {
            Shoot();
            shootTimer = shootDelay;
        }
    }

    void Shoot()
    {
        if (target == null)
        {
            LockTarget();
        }

        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            GameObject newProjectile = Instantiate(arrow, transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody2D>().velocity = direction * newProjectile.GetComponent<ArrowController>().Speed;
        }
    }

    void LockTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                if (target == null)
                {
                    target = enemy.transform;
                }
                else
                {
                    if(Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, target.position))
                    {
                        target = enemy.transform;
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
