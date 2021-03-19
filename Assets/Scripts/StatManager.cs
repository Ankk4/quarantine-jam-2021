using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{

    private static StatManager _instance;
    public static StatManager Instance { get { return _instance; } }


    //speedInblood, hp, fitness, hunger, money, speedInPocket

    public int SpeedInBlood { get; set; }
    public int Hp { get; set; }
    public int Fitness { get; set; }
    public int Hunger { get; set; }
    public int Money { get; set; }
    public int SpeedInPocket { get; set; }
    public int Paranoia { get; set; }

    private int maxValue = 100;

    // Start is called before the first frame update
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SpeedInBlood = 25;
        Hp = 100;
        Fitness = 50;
        Hunger = 50;
        Money = 100;
        SpeedInPocket = 0;
    }

}
