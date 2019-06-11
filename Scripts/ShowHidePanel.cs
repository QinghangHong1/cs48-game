using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ShowHidePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
