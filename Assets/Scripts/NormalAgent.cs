using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NormalAgent : Agent{
    // The prefab for the target, and the actual target
    [SerializeField] private Target targetPrefab;
    private Target target;

    // The Nav Mesh Agent used to move the agent
    private NavMeshAgent agent;

    public override void Awake(){
        // Initialize the base class
        base.Awake();

        // Retrieve the Nav Mesh Agent component
        agent = GetComponent<NavMeshAgent>();

        // Create the target
        target = Instantiate<Target>(targetPrefab, transform.position, targetPrefab.transform.rotation);
    }

    public override void SetTarget(Vector3 targetPosition){
        // Set the target position
        target.position = targetPosition;
        agent.destination = targetPosition;
    }

    public override void HideTargets(){
        // Hide the target
        target.Hide();
    }

    public override void ShowTargets(){
        // Show the target
        target.Show();
    }
}
