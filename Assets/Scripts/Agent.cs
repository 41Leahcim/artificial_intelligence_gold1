using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour{
    // The color to let the user know whether the agent is selected or not
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;

    // Contains the actual material of the agent
    private Material material;

    // Allows other scripts to know whether the agent is selected
    public bool Selected{get; private set;} = false;

    public virtual void Awake(){
        // Retrieve the renderer material
        material = GetComponent<Renderer>().material;
    }

    public void Deselect(){
        // Change to the unselected color and hide targets, when the agent is deselected
        material.color = unselectedColor;
        Selected = false;
        HideTargets();
    }

    public void Select(){
        // Change to the selected color and show targets, when the agent is selected
        material.color = selectedColor;
        Selected = true;
        ShowTargets();
    }

    // Decide in the child classes how targets are set, hidden, and shown
    public abstract void SetTarget(Vector3 targetPosition);
    public abstract void HideTargets();
    public abstract void ShowTargets();
}
