using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour {

    [SerializeField] private float speed = 1.0f;
    private float rotationSpeed = 10f;
    private bool isMoving = false;
    private int currentPositionIndex = 0;

    private Transform[] targets;
    

    private void Update () {
        
        if(isMoving) {
            MoveZombie();
        }
    }

    public void SetZombieMovementPoints (Transform[] targetTransforms) {
        targets = targetTransforms;
        isMoving = true;
    }

    private void MoveZombie () {
        if (currentPositionIndex < targets.Length) {
            Vector3 targetPosition = targets[currentPositionIndex].position;
            Vector3 moveDirection = targetPosition - transform.position;
            moveDirection.y = 0;
            transform.position += moveDirection.normalized * speed * Time.deltaTime;
            transform.forward = Vector3.Slerp(transform.forward, -moveDirection, Time.deltaTime * rotationSpeed);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
                currentPositionIndex++;
            }
        }
    }

}
