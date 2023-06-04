using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AgentMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    // Allows for other scripts to know whether the mouse is currently on the menu
    public bool mouseOver{get; private set;} = false;

    // Update the status when the pointer enters or leaves the menu
    public void OnPointerEnter(PointerEventData eventData) => mouseOver = true;
    public void OnPointerExit(PointerEventData eventData) => mouseOver = false;
}
