using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float speedMultiplier;
    public float slowDownMultiplier;
    public float jumpMultiplier;
    public float jumpTolerance;
    public Transform rotationReference;

    private Rigidbody rib;
    private CapsuleCollider col;
    private static float MIN_SENSITIVITY = 0.05f;
    private float inputY;
    private float inputX;
    private float initSpeedMultiplier;
    private float initSlowDownMultiplier;
    private bool playerIsJumping;
    private int xState;
    private int yState;

    //PHYSICS BASED PLAYER CONTROLLER

    // Use this for initializatio
    private void Start()
    {
        rib = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        playerIsJumping = false;
        initSpeedMultiplier = speedMultiplier;
        initSlowDownMultiplier = slowDownMultiplier;
    }

    private void FixedUpdate()
    {
        yState = moveForward();
        xState = moveRight();
        isJumping();
        Jump();
        checkMovementVelocity(xState, yState);
        Rotation(rotationReference);
        //Debug.Log(rib.velocity.magnitude);
    }

    //Forward/backward movement code
    private int moveForward()
    {
        inputY = Input.GetAxis("Vertical");

        if (inputY > MIN_SENSITIVITY || inputY < -(MIN_SENSITIVITY))
        {
            rib.AddForce(transform.forward * inputY * speedMultiplier);
            return 1;
        }
        if (inputY < MIN_SENSITIVITY || inputY > -(MIN_SENSITIVITY))
        {
            Vector3 inverseVelocity = rib.velocity * slowDownMultiplier;
            rib.AddForce(-(inverseVelocity));
            return 0;
        }
        else
        {
            return 0;
        }
    }

    //right/left
    private int moveRight()
    {
        inputX = Input.GetAxis("Horizontal");
        if (inputX > MIN_SENSITIVITY || inputX < -(MIN_SENSITIVITY))
        {
            rib.AddForce(transform.right * inputX * speedMultiplier);
            return 1;
        }
        if (inputX < MIN_SENSITIVITY || inputX > -(MIN_SENSITIVITY))
        {
            Vector3 inverseVelocity = rib.velocity * slowDownMultiplier;
            rib.AddForce(-(inverseVelocity));
            return 0;
        }
        else
        {
            return 0;
        }
    }

    // Apply a force from the players local up direction.
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (playerIsJumping == false)
            {
                rib.AddForce(transform.up * jumpMultiplier);
            }
        }
    }

    //casts ray from bottom of mesh to floor
    // if value is above tolerated level player is jumping
    // else player is not jumping 

    void isJumping()
    {
        Vector3 minPoint = col.bounds.min;
        RaycastHit hit;
        Ray ray = new Ray(minPoint, -(transform.up));

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.distance);
            if (hit.distance > jumpTolerance)
            {
                playerIsJumping = true;
                rib.drag = 0f;

            }
            else
            {
                playerIsJumping = false;
                rib.drag = 1;
            }
        }
    }

    //if player is moving diagonallly, half force applied in both directions
    void checkMovementVelocity(int xState, int yState)
    {
        if (xState == 1 && yState == 1)
        {
            speedMultiplier = initSpeedMultiplier / 2f;
            slowDownMultiplier = initSlowDownMultiplier * 4;
        }
        else
        {
            speedMultiplier = initSpeedMultiplier;
            slowDownMultiplier = initSlowDownMultiplier;
        }
    }

    private void Rotation(Transform referenceTransform)
    {
        Vector3 referenceRotation = referenceTransform.eulerAngles;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, referenceRotation.y, transform.eulerAngles.z);

    }

}
