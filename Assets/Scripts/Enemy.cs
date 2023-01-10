using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldAdd = 25;
    [SerializeField] int goldStolen = 25;

    Bank bank;

    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void AddGold()
    {
        bank.Deposit(goldAdd);
    }

    public void StealGold()
    {
        bank.Withdraw(goldStolen);
    }
}
