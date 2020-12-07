﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] float pushPower = 2;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            ItemInterface item = (ItemInterface)hit.gameObject.GetComponent(typeof(ItemInterface));
            item.get();
            return;
        }

        Rigidbody body = hit.collider.attachedRigidbody;

        if (hit.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Enemy");
            EnemyInterface enemy = (EnemyInterface)hit.gameObject.GetComponent(typeof(EnemyInterface));
            int dmg = enemy.getEnemyDamage();
            gameManager.plusPower(-dmg);
        }

        if (body == null || body.isKinematic) { return; }


        if(hit.gameObject.layer == LayerMask.NameToLayer("Pushable"))
        {
            body.AddForceAtPosition(Vector3.down * pushPower, hit.point);
        }



        
    }
}
