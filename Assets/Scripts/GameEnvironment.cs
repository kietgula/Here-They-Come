using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public sealed class GameEnvironment
{
    //Singleton setup
    private static GameEnvironment instance;
    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
            }
            return instance;
        }
    }
    //

    // Singleton Data

    //Toppers
    private List<GameObject> toppers = new List<GameObject>();
    public List<GameObject> Toppers { get { return toppers; } }
    //Botters
    private List<GameObject> botters = new List<GameObject>();
    public List<GameObject> Botters { get { return botters; } }
    //Dead Botters
    private List<GameObject> deadBotters = new List<GameObject>();
    public List<GameObject> DeadBotters { get { return deadBotters; } }

    //Balance
    private int balance = 500;
    public int Balance
    {
        get { return balance; }
        //set { Balance = value; }
    } 

    public void AddMoney(int value)
    {
        balance += value;
    }

    public void ReduceMoney(int value)
    {
        balance -= value;
    }



    public void AddTopper(GameObject topper)
    {
        toppers.Add(topper);
    }

    public void RemoveTopper(GameObject topper)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = toppers.IndexOf(topper);
        toppers.RemoveAt(index);
    }

    public void AddBotter(GameObject botter)
    {
        botters.Add(botter);
    }

    public void RemoveBotter(GameObject botter)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = botters.IndexOf(botter);
        botters.RemoveAt(index);
    }

    public void AddDeadBotter(GameObject deadBotter)
    {
        deadBotters.Add(deadBotter);
    }

    public void RemoveDeadBotter(GameObject deadBotter)
    {
        //this list method allow me to find the index of a element stored in it. This is soooo useful
        int index = deadBotters.IndexOf(deadBotter);
        deadBotters.RemoveAt(index);
    }

    public void Reset()
    {
        instance = null;
        balance = 500;
    }

}
