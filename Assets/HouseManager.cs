using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour
{
    private static HouseManager _instance;
    public static HouseManager Instance { get { return _instance; } }


    private List<string> dealerNames = new List<string>();

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

        dealerNames.Add("Hassan");
        dealerNames.Add("Bob");
        dealerNames.Add("Dimitri");
        dealerNames.Add("Leroy");
        dealerNames.Add("Sminem");

    }

    public List<string> GetDealers()
    {
        int numberOfDealers = Random.Range(1,4);

        List<string> dealersRandomized = new List<string>();

        int iterator = 0;
        while(iterator < numberOfDealers)
        {
            int indexOfDealer = Random.Range(1,dealerNames.Count);
            if(!dealersRandomized.Contains(dealerNames[indexOfDealer]))
            {
                dealersRandomized.Add(dealerNames[indexOfDealer]);
                iterator++;
            }
        }

        return dealersRandomized;
    }
}
