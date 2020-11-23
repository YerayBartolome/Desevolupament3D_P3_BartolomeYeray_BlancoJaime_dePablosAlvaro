using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTransform : MonoBehaviour
{
    [SerializeField] Transform initialTransform;

    Vector3 initPos;
    Quaternion initRot;

    void Start()
    {
        GameManager.RestartGameEvent += Restart;
        initPos = transform.position;
        initRot = transform.rotation;
    }

    public virtual void Restart()
    {
        if (initialTransform != null)
        {
            transform.position = initialTransform.position;
            transform.rotation = initialTransform.rotation;
        } else
        {
            transform.position = initPos;
            transform.rotation = initRot;
        }
        
    }

    protected void OnEnable()
    {
        GameManager.RestartGameEvent += Restart;
    }

    protected void OnDisable()
    {
        GameManager.RestartGameEvent -= Restart;
    }

}
