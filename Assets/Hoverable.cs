using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Events;

public class Hoverable : MonoBehaviour
{
    [SerializeField] private string toolTipText;
    [SerializeField] private Color HighlightColor = Color.yellow;
    [SerializeField] private GameObject tooltipPrefab;

    private Color normalColor = Color.white;
    private GameObject tooltip;

    public UnityEvent onClicked;

    private bool canClick;

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {         
            return;
        }
        canClick = true;
        //gameObject.GetComponentInChildren<Renderer>().material.color = HighlightColor;
        tooltip = Instantiate(tooltipPrefab, FindObjectOfType<Canvas>().transform);
        tooltip.transform.position = Input.mousePosition;
        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = toolTipText;
    }

    private void OnMouseExit()
    {
        canClick = false;
        //gameObject.GetComponentInChildren<Renderer>().material.color = normalColor;
        Destroy(tooltip);
    }

    private void OnMouseDown()
    {
        if(!canClick) return;
        Destroy(tooltip);
        onClicked.Invoke();
        canClick = false;
    }


}
