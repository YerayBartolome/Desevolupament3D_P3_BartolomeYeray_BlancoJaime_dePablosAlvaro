using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem :MonoBehaviour, ItemInterface
{
    [SerializeField] Transform gameManagerObject;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
    public void get()
    {
        gameManager.plusPower(1);
        Debug.Log("get power");
        Destroy(transform.parent.gameObject);
    }
}
