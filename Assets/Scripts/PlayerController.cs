using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    PlayerResetTransform playerResetTransform;

    [SerializeField] Transform cam;
    [SerializeField] float speedMultiplier = 3f;
    [SerializeField] float speed = 2.3f;
    [SerializeField] float smoothTimeRotate = 0.07f;
    [SerializeField] float smoothTimeMove = 0.01f;
    [SerializeField] float maxRotationSpeed = 20f;
    [SerializeField] float maxAcceleration = 250f;
    [SerializeField] float timeScale = 1f;
    [SerializeField] float gravity = 1.5f;
    [SerializeField] int maxJumps = 3;
    [SerializeField] float jumpForce = 0.5f;
    [SerializeField] float jumpForce2 = 0.6f;
    [SerializeField] float jumpForce3 = 0.7f;
    [SerializeField] float timeUntilResetJump = 1f;


    //private bool canJump = false;
    private int jumpsAvailable = 0;
    float l_up = 0f;
    float landTime = -1f;

    enum Jump
    {
        Normal,
        Double,
        Triple
    }

    Jump currentJump;
    Jump NextJump = Jump.Normal;
    bool justJumped = false;
    bool spacePressed = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerResetTransform = GetComponent<PlayerResetTransform>();
    }
    

    private Vector3 currentMovement = Vector3.zero; //Stores CharacterController absolute movement deltas at the end of each fixed frame;

    public void setCheckPoint(CheckPoint newCheckPoint)
    {
        //player checkPoints implementation
        playerResetTransform.setCheckPoint(newCheckPoint);
    }



    void FixedUpdate()
    {
        Vector3 l_Movement = Vector3.zero;
        Vector3 l_forward = cam.forward;
        Vector3 l_right = cam.right;
        


        l_forward.y = 0.0f;
        l_forward.Normalize();

        l_right.y = 0.0f;
        l_right.Normalize();
                       

        if (Input.GetKey(KeyCode.W))
        {
            l_Movement += l_forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            l_Movement -= l_forward;
        } if (Input.GetKey(KeyCode.D))
        {
            l_Movement += l_right;
        } if (Input.GetKey(KeyCode.A))
        {
            l_Movement -= l_right;
        }

        l_Movement.Normalize();

        bool l_isMoving = l_Movement.magnitude > 0.01f;

        Vector3 l_velocity = Vector3.zero;
        float a_TurnVelocity = 0;
        if (l_isMoving)
        {
            a_TurnVelocity = Vector3.Angle(transform.forward, l_Movement);
            Vector3 newForward = Vector3.SmoothDamp(transform.forward, new Vector3(l_Movement.x, l_Movement.y, l_Movement.z), ref l_velocity, a_TurnVelocity/smoothTimeRotate, maxRotationSpeed);
            a_TurnVelocity = Vector3.Angle(transform.forward, newForward);
            animator.SetBool("MirrorTurn", !(Vector3.Cross(transform.forward, newForward).y < 0));          // !(Vector3.Cross(transform.forward, newForward).y < 0)
            transform.forward = newForward;
            
        }

        float currentSpeedMultiplier = 1.0f;

        float l_velocity0 = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedMultiplier = speedMultiplier;
        }
        Vector3 velocity = currentMovement;

        

        l_Movement *= speed * currentSpeedMultiplier;

        

        if (!characterController.isGrounded) justJumped = true;
        if(justJumped && characterController.isGrounded)
        {
            if (landTime < 0f) landTime = Time.time;
            else if (landTime + timeUntilResetJump <= Time.time)
            {
                NextJump = Jump.Normal;
                landTime = -1f;
                
            }
        }

        if (characterController.isGrounded) l_up = 0f;
        if (Input.GetKey(KeyCode.Space) && characterController.isGrounded)
        {


            switch (NextJump)
            {
                case Jump.Normal:
                    l_up += jumpForce;
                    Debug.Log("Normal jump");
                    NextJump = Jump.Double;
                    break;
                case Jump.Double:
                    l_up += jumpForce2;
                    Debug.Log("Double jump");
                    NextJump = Jump.Triple;
                    break;
                case Jump.Triple:
                    l_up += jumpForce3;
                    Debug.Log("Triple jump");
                    NextJump = Jump.Normal;
                    break;
            }
        }

        l_up -= gravity * Time.fixedDeltaTime;


        currentMovement.y = l_up;

        currentMovement = Vector3.SmoothDamp(currentMovement, l_Movement * Time.fixedDeltaTime, ref velocity, smoothTimeMove);
        
        characterController.Move(currentMovement);
        Vector3 translationalMovement = new Vector3(currentMovement.x, 0, currentMovement.z);
        animator.SetFloat("Speed", (translationalMovement.magnitude / (speed * speedMultiplier)) / 0.02f);
        animator.SetFloat("TurnSpeed", a_TurnVelocity);
        animator.SetInteger("JumpsAvailable", jumpsAvailable);
    }


}
