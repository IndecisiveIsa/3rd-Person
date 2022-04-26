using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    private InputManager input;

    public Transform targetTransform; //what the camera rig is tracking
    public Transform camTransform; //the location of the maincamera
    public Transform pivotTransorm; //the location of the pivot



    //sensitivity variables
    public float lookSpeed = .03f;
    public float followSpeed = .1f;
    public float pivotSpeed = .03f;
    private Vector3 cameraFollowVelocity = Vector3.zero;

    // for camera zoom
    public float targetPos;
    private float defaultPos;
    private Vector3 camPos; // the position data of the camera. Only matters for z position.
    public LayerMask ignoreLayers;


    //limit camera rotation
    private float lookAngle;
    private float pivotAngle;
    public float minpivot = -35;
    public float maxpivot = 35;

    //for detecting if the target is obscured
    public float cameraSphereRadius = .2f;
    public float cameraCollisionOffset = .2f;
    public float minCollisionOffset = .2f;

    private Vector3 Direction;


    private void Awake()
    {
        defaultPos = camTransform.localPosition.z;
    }


    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget(Time.deltaTime);
        HandleCameraRotation(Time.deltaTime);
        HandleCameraCollision(Time.deltaTime);
    }

    private void FollowTarget(float delta)
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, delta/followSpeed);
        transform.position = targetPosition;
    }

    private void HandleCameraRotation(float delta)
    {
        //Store the values from input
        float mouseX = input.look.x;
        float mouseY = input.look.y;

        //calculate 'looking' AKA y rotation angle
        lookAngle += (mouseX * lookSpeed) / delta;

        //calculate 'pivot' AKA x rotation angle
        pivotAngle -= (mouseY * pivotSpeed) / delta;

        //clamp the pivot so we can't tilt so far
        pivotAngle = Mathf.Clamp(pivotAngle, minpivot, maxpivot);

        //THE FOLLOWING SECTION APPLES Y AXIS ROTATION

        //create a Vector3 to store the new rotation
        Vector3 rotation = Vector3.zero;

        rotation.y = lookAngle;

        //Make a quaternion out of the euler angle
        Quaternion targetRotation = Quaternion.Euler(rotation);

        transform.rotation = targetRotation;

        //THE FOLLOWING SECTION APPLIES X AXIS ROTATION

        rotation = Vector3.zero;

        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);

        pivotTransorm.localRotation = targetRotation;


    }

    private void HandleCameraCollision(float delta)
    {
        //constantly trying to put the camera back to default
        targetPos = defaultPos;

        // create a raycast hit to store raycast data
        RaycastHit Hit;

        Vector3 direction = camTransform.position - pivotTransorm.position;
        direction.Normalize();

        // cast a sphere from the pivot to the camera
        if (Physics.SphereCast(pivotTransorm.position, cameraSphereRadius, direction, out Hit, Mathf.Abs(targetPos), ignoreLayers))
        {
            //if we hit something, find out how far it was from the pivot to that point
            float dis = Vector3.Distance(pivotTransorm.position, Hit.point);

            //update the target with negative this distance
            targetPos = -(dis - cameraCollisionOffset);

            // if our new target position is less than our minimum offset, set the camera to the minimum
            if(Mathf.Abs(targetPos) < minCollisionOffset)
            {
                targetPos = -minCollisionOffset;
            }
        }

        camPos.z = Mathf.Lerp(camTransform.localPosition.z, targetPos, delta / .2f);

        camTransform.localPosition = camPos;
    }

   


}
