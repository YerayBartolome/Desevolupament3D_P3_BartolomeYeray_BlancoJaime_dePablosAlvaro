using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform m_lookAt;
    Vector3 offset;

    private void Start()
    {
        offset = m_lookAt.position - transform.position;
    }

    private void Update()
    {
        transform.position = m_lookAt.position - offset;
    }
}
