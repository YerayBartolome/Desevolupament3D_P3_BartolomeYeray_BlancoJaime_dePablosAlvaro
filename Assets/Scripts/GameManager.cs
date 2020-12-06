using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public int lifes = 3;
    private int power = 8;
    private int coins = 0;

    public delegate void RestartGameDelegate();
    public static event RestartGameDelegate RestartGameEvent;

    

    public void RestartGame()
    {
        RestartGameEvent.Invoke();
    }

    public int Power
    {
        get { return power; }
    }

    public void plusPower(int n)
    {
        if (power + n >= 8) power = 8;
        if (power + n <= 0)
        {
            power = 0;
            Die();
        }
        power += n;
    }

    public int Coins
    {
        get { return coins; }
    }

    public void plusCoins(int n)
    {
        if (coins + n <= 0) coins = 0;
        coins += n;
    }

    public void Die()
    {
        //Die mario animation
        if (lifes > 0)
        {
            //ShowDeathMenu
        }
        else
        {
            //End Game
        }
    }

}
