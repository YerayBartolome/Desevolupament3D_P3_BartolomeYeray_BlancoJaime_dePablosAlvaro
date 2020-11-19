using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public KeyCode m_DebugLockAngleKeyCode = KeyCode.I;
    public KeyCode m_DebugLockKeyCode = KeyCode.O;
    bool m_AngleLocked = false;
    bool m_CursorLocked = true;

    [SerializeField] Transform m_LookAt;
    [SerializeField] float m_YawSpeed, m_PitchSpeed, m_MinPitch = -45.0f, m_MaxPitch = 75.0f, m_MinDistance, m_MaxDistance;
    [SerializeField]
    LayerMask m_LayerMask;
    [SerializeField]
    float m_AvoidObstacleOffset;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_CursorLocked = true;
    }
    void OnApplicationFocus()
    {
        if (m_CursorLocked)
            Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(m_DebugLockAngleKeyCode))
            m_AngleLocked = !m_AngleLocked;
        if (Input.GetKeyDown(m_DebugLockKeyCode))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
            m_CursorLocked = Cursor.lockState == CursorLockMode.Locked;
        }
#endif

        float l_MouseAxisX = Input.GetAxis("Mouse X");
        float l_MouseAxisY = Input.GetAxis("Mouse Y");

        Vector3 l_Direction = m_LookAt.position - transform.position;
        float l_Distance = l_Direction.magnitude;

        Vector3 l_DesiredPosition = transform.position;

        if (!m_AngleLocked && (Mathf.Abs(l_MouseAxisX) > 0.01f || Mathf.Abs(l_MouseAxisY) > 0.01f))
        {
            Vector3 l_EulerAngles = transform.rotation.eulerAngles;
            float l_Yaw = l_EulerAngles.y + 180.0f;
            float l_Pitch = l_EulerAngles.x;

            //Calculate and clamp Yaw and Pitch

            l_Yaw += l_MouseAxisX * m_YawSpeed;
            if (l_Yaw > 360.0f) l_Yaw -= 360.0f;
            if (l_Yaw < 0f) l_Yaw += 360.0f;
            l_Yaw *= Mathf.Deg2Rad;

            l_Pitch += l_MouseAxisY * -1 * m_PitchSpeed;
            if (l_Pitch > 180.0f) l_Pitch -= 360.0f;

            l_Pitch *= Mathf.Deg2Rad;
            l_Pitch = Mathf.Clamp(l_Pitch, m_MinPitch, m_MaxPitch);

            //Update values


            l_DesiredPosition = m_LookAt.position + new Vector3(
                Mathf.Sin(l_Yaw) * Mathf.Cos(l_Pitch) * l_Distance,
                Mathf.Sin(l_Pitch) * l_Distance,
                Mathf.Cos(l_Yaw) * Mathf.Cos(l_Pitch) * l_Distance);
            l_Direction = m_LookAt.position - l_DesiredPosition;

        }

        l_Direction.Normalize();

        if (l_Distance > m_MaxDistance || l_Distance < m_MinDistance)
        {
            l_Distance = Mathf.Clamp(l_Distance, m_MinDistance, m_MaxDistance);
            l_DesiredPosition = m_LookAt.position - l_Direction * l_Distance;
        }

        Ray l_ray = new Ray(m_LookAt.position, -l_Direction);
        if (Physics.Raycast(l_ray, out RaycastHit l_hit, l_Distance, m_LayerMask))
        {
            l_DesiredPosition = l_hit.point + m_AvoidObstacleOffset * l_Direction;
        }

        transform.position = l_DesiredPosition;
        transform.forward = l_Direction;
    }
}