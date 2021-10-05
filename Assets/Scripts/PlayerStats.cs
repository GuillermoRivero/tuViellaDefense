using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Money;
    public static int Lives;
    public static int Rounds;
    public int startMoney = 400;
    public int startLives = 10;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
