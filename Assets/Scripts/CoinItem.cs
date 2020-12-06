using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour, ItemInterface
{
    [SerializeField] Transform gameManagerObject;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }
    public void get()
    {
        gameManager.plusCoins(1);
        Debug.Log("get coin");
        Destroy(transform.parent.gameObject);
    }
    
}
