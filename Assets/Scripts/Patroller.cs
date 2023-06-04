using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Patroller : Agent{
    // A prefab of the target and the actual targets
    [SerializeField] private Target targetPrefab;
    private Target[] targets = new Target[2];

    // A reference to the Nav Mesh Agent component, used to move the patroller
    private NavMeshAgent agent;

    // The index of the target to move to, and the index of the target to move
    private int targetIndex = 0;
    private int targetSetIndex = 0;

    public override void Awake(){
        // Initialize the base class
        base.Awake();

        // Retrieve the agent component
        agent = GetComponent<NavMeshAgent>();

        // Create the targets, put them on the location of the agent for now
        targets[0] = Instantiate<Target>(targetPrefab, transform.position, targetPrefab.transform.rotation);
        targets[1] = Instantiate<Target>(targetPrefab, transform.position, targetPrefab.transform.rotation);
    }

    void Update(){
        // Set the target location to move to
        agent.destination = targets[targetIndex].position;

        // Convert the current position and target position to 2D
        Vector2 position = Vector2.right * transform.position.x + Vector2.up * transform.position.z;
        Vector2 targetPosition = Vector2.right * agent.destination.x + Vector2.up * agent.destination.z;

        // Select the next target, if the agent reached it's destination
        if(Vector2.Distance(position, targetPosition) == 0){
            targetIndex = (targetIndex + 1) % targets.Length;
        }
    }

    public override void SetTarget(Vector3 targetPosition){
        // Set the target and continue to the next target to set
        targets[targetSetIndex].position = targetPosition;
        targetSetIndex = (targetSetIndex + 1) % targets.Length;
    }

    public override void HideTargets(){
        // Hide the targets
        targets[0].Hide();
        targets[1].Hide();
    }

    public override void ShowTargets(){
        // Show the targets
        targets[0].Show();
        targets[1].Show();
    }
}
