using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class AgentManager : MonoBehaviour{
    // Set the normal agent and patroller prefabs
    [SerializeField] private Agent normalAgent;
    [SerializeField] private Agent patroller;

    // Store a reference to the menu to prevent a click on the menu from triggering a spawn or movement
    [SerializeField] private AgentMenu agentMenu;

    // The selected agent and prefab
    private Agent selectedAgent = null;
    private Agent selectedPrefab;

    void Awake(){
        // Select the normal agent as default
        selectedPrefab = normalAgent;
    }
    
    void OnClick(InputValue value){
        // Ignore the click, if it was on the agent menu
        if(agentMenu.mouseOver){
            return;
        }

        // Calculate the source of the ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        // We will use the agent layer to more easily check whether the player clicked on an agent
        int agentLayer = 1 << LayerMask.NameToLayer("Agent");

        // Cast a ray for an agent
        if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity, agentLayer)){
            // Retrieve and select the agent
            Agent agent = raycastHit.collider.GetComponent<Agent>();
            SelectAgent(agent);
        }else if(Physics.Raycast(ray, out raycastHit)){
            // If the ray didn't hit an agent and no agent is selected, we create a new agent
            // If an agent is selected, we spawn a new agent
            if(selectedAgent == null){
                Agent prefab = selectedPrefab;
                Agent agent = Instantiate<Agent>(prefab, raycastHit.point, prefab.transform.rotation);
                SelectAgent(agent);
            }else{
                selectedAgent.SetTarget(raycastHit.point);
            }
        }
    }

    // Select the agent based on input
    void OnNormalAgent(InputValue value) => SelectAgentType(normalAgent);
    void OnPatroller(InputValue value) => SelectAgentType(patroller);

    void SelectAgent(Agent agent){
        // We can't select a non-existing agent
        if(agent == null){
            return;
        }
        
        // Deselect the previous agent, if one was selected
        if(selectedAgent != null){
            selectedAgent.Deselect();
        }

        // Select the agent, if it wasn't already selected
        if(agent != selectedAgent){
            selectedAgent = agent;
            agent.Select();
        }else{
            selectedAgent = null;
        }
    }

    public void SelectAgentType(Agent agent){
        // Select the new agent prefab
        selectedPrefab = agent;

        // Deselect any currently selected agent
        if(selectedAgent != null){
            selectedAgent.Deselect();
            selectedAgent = null;
        }
    }
}
