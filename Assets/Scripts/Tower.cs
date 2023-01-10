using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 50;
    Bank bank;

    void Start()
    {
        StartCoroutine(BuildDelay());
        
    }
    public bool CreateTower(Tower tower, Vector3 position)
    {
        bank = FindObjectOfType<Bank>();

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(cost);
            
            return true;
        }

        return false;
    }

    IEnumerator BuildDelay()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach(Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);

            yield return new WaitForSeconds(2);
            foreach (Transform grandChild in child)
            {
                grandChild.gameObject.SetActive(true);
            }
        }
    }
  
}
