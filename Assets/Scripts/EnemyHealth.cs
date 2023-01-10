using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;

    int currentHitpoints = 0;

    Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        
    }

    void OnParticleCollision(GameObject other)
    {
        currentHitpoints--;
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            enemy.AddGold();
        }
        
    }
}
