using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUI : MonoBehaviour
{
    [SerializeField] RectTransform drugdealersList;
    [SerializeField] GameObject dealerListItemPrefab;

    public void InitializeUI(List<string> names)
    {
        foreach(string dealer in names)
        {
            GameObject dealerListItem = Instantiate(dealerListItemPrefab, drugdealersList);
            dealerListItem.GetComponentInChildren<TextMeshProUGUI>().text = dealer;
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

}
