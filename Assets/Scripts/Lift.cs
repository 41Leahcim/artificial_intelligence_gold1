using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lift : MonoBehaviour{
    // Positions for the lift to move between
    [SerializeField] private Vector3[] positions;

    // The speed at which the lift moves and how long it waits at each position
    [SerializeField] private float speed = 1;
    [SerializeField] private float waitTimeSeconds = 1;

    // The position it's currently at or moving to, and whether it's waiting there
    private int positionIndex;
    private bool waiting = false;

    void Update(){
        // When it's not waiting, it should move to the next position
        if(!waiting){
            Move();
        }
    }

    void Move(){
        // Move the lift
        transform.position = Vector3.MoveTowards(
            transform.position,
            positions[positionIndex],
            speed * Time.deltaTime
        );

        // Set the next position, if it reached the current one
        if(transform.position == positions[positionIndex]){
            positionIndex = (positionIndex + 1) % positions.Length;
            StartCoroutine(WaitOnLevel());
        }
    }

    IEnumerator WaitOnLevel(){
        // Wait to allow an agent to enter or leave
        waiting = true;
        yield return new WaitForSeconds(waitTimeSeconds);
        waiting = false;
    }
}
