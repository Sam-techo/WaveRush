using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    [SerializeField] TextMeshProUGUI displayGold;
    public int CurrentBalance { get { return currentBalance; } }

    void Start()
    {
        currentBalance = startingBalance;
        Display();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        Display();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        Display();
        
        if (currentBalance < 0)
        {
            ReloadScene();
        }

    }

    void Display()
    {
        displayGold.text = "Gold:" + currentBalance;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
