using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticle;
    [SerializeField] float enemyRange = 15f;
    Transform enemyTarget;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
        TargetFollow();
    }

    void FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float maxDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            
            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        enemyTarget = closestTarget;

    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }

    void TargetFollow()
    {
        float targetDistance = Vector3.Distance(transform.position, enemyTarget.position);

        weapon.LookAt(enemyTarget);

        if (targetDistance < enemyRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        
    }
}
