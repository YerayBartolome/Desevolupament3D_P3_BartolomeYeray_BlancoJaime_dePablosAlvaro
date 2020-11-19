using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] float speedMultiplier = 3f;
    [SerializeField] float speed = 2.3f;
    [SerializeField] float smoothTimeRotate = 0.07f;
    [SerializeField] float smoothTimeMove = 0.01f;
    [SerializeField] float maxRotationSpeed = 20f;
    [SerializeField] float maxAcceleration = 250f;

    [SerializeField] float timeScale = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Time.timeScale = timeScale;
    }

    private Vector3 currentMovement = Vector3.zero; //Stores CharacterController absolute movement deltas at the end of each fixed frame;
    void FixedUpdate()
    {
        Vector3 l_Movement = Vector3.zero;
        Vector3 l_forward = cam.forward;
        Vector3 l_right = cam.right;

        l_forward.y = 0.0f;
        l_forward.Normalize();

        l_right.y = 0.0f;
        l_right.Normalize();

        

        if (Input.GetKey(KeyCode.UpArrow))
        {
            l_Movement += l_forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            l_Movement -= l_forward;
        } if (Input.GetKey(KeyCode.RightArrow))
        {
            l_Movement += l_right;
        } if (Input.GetKey(KeyCode.LeftArrow))
        {
            l_Movement -= l_right;
        }

        l_Movement.Normalize();

        bool l_isMoving = l_Movement.magnitude > 0.01f;

        Vector3 l_velocity = Vector3.zero;
        float a_TurnVelocity = 0;
        if (l_isMoving)
        {
            Vector3 newForward = Vector3.SmoothDamp(transform.forward, l_Movement, ref l_velocity, smoothTimeRotate, maxRotationSpeed);
            a_TurnVelocity = Vector3.Angle(transform.forward, newForward);
            animator.SetBool("MirrorTurn", !(Vector3.Cross(transform.forward, newForward).y < 0));
            transform.forward = newForward;
            
        }

        float currentSpeedMultiplier = 1.0f;

        float l_velocity0 = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedMultiplier = speedMultiplier;
        }
        Vector3 velocity = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        l_Movement *= speed * currentSpeedMultiplier;
        currentMovement = Vector3.SmoothDamp(currentMovement, l_Movement * Time.fixedDeltaTime, ref velocity, smoothTimeMove, maxAcceleration);
        characterController.Move(currentMovement);
        animator.SetFloat("Speed", (currentMovement.magnitude / (speed * speedMultiplier)) / 0.02f);
        animator.SetFloat("TurnSpeed", a_TurnVelocity);
    }
}
