using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float moveSpeed = 5f;

    private bool isWalking = false;

    private void Update () {

        Vector2 inputVector = new Vector2(0, 0);


        if(Input.GetKey(KeyCode.W)) {
            inputVector.y = -1;                
        }

        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = +1;
        }

        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = -1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        isWalking = moveDirection.magnitude > 0;

        float rotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public bool GetWalkingState() {
        return isWalking;
    }
}