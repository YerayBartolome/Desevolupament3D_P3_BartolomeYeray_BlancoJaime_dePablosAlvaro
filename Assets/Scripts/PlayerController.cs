using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    CharacterController characterController;
    [SerializeField] Transform cam;
    [SerializeField] float speedMultiplier = 2.0f;
    [SerializeField] float speed = 5.0f;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            l_Movement += l_forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            l_Movement -= l_forward;
        }if (Input.GetKey(KeyCode.RightArrow))
        {
            l_Movement += l_right;
        }if (Input.GetKey(KeyCode.LeftArrow))
        {
            l_Movement -= l_right;
        }

        l_Movement.Normalize();

        bool l_isMoving = l_Movement.magnitude > 0.01f;
        if (l_isMoving) transform.forward = l_Movement;

        float currentSpeedMultiplier = 1.0f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeedMultiplier = speedMultiplier;
        }

        l_Movement *= speed * currentSpeedMultiplier;

        characterController.Move(l_Movement * Time.fixedDeltaTime);
        animator.SetFloat("Speed", (l_Movement.magnitude) / (speed * speedMultiplier));

        Debug.Log(speed);
    }
}
