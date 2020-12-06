using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyGoomba : MonoBehaviour, EnemyInterface
{
    Animator animator;
    private NavMeshAgent nav;
    private Vector3 target;
    bool chasing = false;
    bool toPointA = true;

    [SerializeField] Transform player;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float atackDistance;
    [SerializeField] float yOffset = 1;
    [SerializeField] int damage = 1;

    




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nav.SetDestination(player.position);

        if (nav.remainingDistance > atackDistance) chasing = true;
        else {
            chasing = false;
            target = pointA.position;
        }
        
        if (chasing)
        {
            target = player.position;
        }
        else
        {
            if (toPointA)
            {
                nav.SetDestination(pointA.position);
                if (nav.remainingDistance < 1f)
                {
                    target = pointB.position;
                    toPointA = false;
                }
            }
            else
            {
                nav.SetDestination(pointB.position);
                if (nav.remainingDistance < 1f)
                {
                    target = pointA.position;
                    toPointA = true;
                }
            }
            
        }
        nav.SetDestination(target);
        animator.SetBool("Chasing", chasing);

        Debug.Log(toPointA);

    }

    public int getEnemyDamage()
    {
        return damage;
    }

    public void TakeHit()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 2);
    }
}
