using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    [SerializeField] float pushPower = 2;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;


        if (body == null || body.isKinematic) { return; }


        if(hit.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            body.AddForceAtPosition(Vector3.down * pushPower, hit.point);
        }
    }
}
