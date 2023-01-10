using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0f, 10f)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 10f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnablePoolObject()
    {
        for (int i =0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnablePoolObject();
            yield return new WaitForSeconds(spawnTimer);
        }
        
    }
}
