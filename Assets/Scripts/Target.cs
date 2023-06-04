using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour{
    // The position of the target, only used component of the transform
    public Vector3 position{
        get{return transform.position;}
        set{ transform.position = value; }
    }

    // The renderer has to be turned on/off to display/hide the target
    private MeshRenderer meshRenderer;

    void Awake(){
        // Retrieve the mesh renderer
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Hide(){
        // Disable the renderer when hidden
        meshRenderer.enabled = false;
    }

    public void Show(){
        // Show the renderer when shown
        meshRenderer.enabled = true;
    }
}
