using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InputManager input;

    private CharacterController controller;

    public Transform camParent;
    public Transform cam;

    public float speed = 5f;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(Time.deltaTime);
        HandleRotation(Time.deltaTime);
    }

    private void HandleMovement(float delta)
    {
        Vector3 movement = (input.move.x * camParent.right) + (input.move.y * camParent.forward);
        controller.Move(movement * speed * delta);
    }

    private void HandleRotation(float delta)
    {
        Vector3 targetDir;

        targetDir = cam.forward * input.move.y;
        targetDir += cam.right * input.move.x;

        targetDir.Normalize();

        targetDir.y = 0;

        if (targetDir == Vector3.zero)
        {
            targetDir = transform.forward;
        }


        Quaternion appliedDir = Quaternion.LookRotation(targetDir);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, appliedDir, rotationSpeed * delta);
    }
}

