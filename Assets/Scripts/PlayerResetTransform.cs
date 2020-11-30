using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetTransform : ResetTransform
{
    protected Transform currentTransform;
    CharacterController characterController;
    protected int checkPointValue = 0;
    void Start()
    {
        Debug.Log("Start player");
        GameManager.RestartGameEvent += Restart;
        initPos = transform.position;
        initRot = transform.rotation;
        currentTransform = initialTransform;
        characterController = GetComponent<CharacterController>();
    }
    public override void Restart()
    {
        Debug.Log("Restart player");
        characterController.enabled = false;
        if (currentTransform != null)
        {
            transform.position = currentTransform.position;
            transform.rotation = currentTransform.rotation;
        }
        else
        {
            transform.position = initPos;
            transform.rotation = initRot;
        }
        characterController.enabled = true;

    }

    public void setCheckPoint(CheckPoint check)
    {

        int newCheckPointValue = check.checkPointValue;
        if (checkPointValue <= newCheckPointValue)
        {
            Debug.Log("New CheckPoint");
            currentTransform = check.transform;
            checkPointValue = newCheckPointValue;
        }
        
    }
}
