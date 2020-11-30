using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int checkPointValue = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
            other.GetComponent<PlayerController>().setCheckPoint(this);
        }
    }
}
