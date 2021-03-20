using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpeed : MonoBehaviour
{
    [SerializeField] GameObject speedUI;
    private List<string> dealers = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Hoverable>().onClicked.AddListener(GoOnComputer);
    }


    private void GoOnComputer()
    {
        GetDealers();
        ShowComputer();
    }

    private void GetDealers()
    {
        if(dealers.Count != 0) return;
        dealers = HouseManager.Instance.GetDealers();
    }

    private void ShowComputer()
    {
        speedUI.SetActive(true);
        if(dealers.Count != 0)
            speedUI.GetComponent<SpeedUI>().InitializeUI(dealers);
    }

}
