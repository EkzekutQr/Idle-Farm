using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellBlock : MonoBehaviour
{
    [SerializeField]
    private BackPackBehavior backPack;

    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject coinSpawnPoint;

    [SerializeField]
    private GameObject coinImage;

    [SerializeField]
    private GameObject coinCounter;

    [SerializeField]
    private GameObject canvas;

    private void GetCoin()
    {
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = coinSpawnPoint.transform.position;
        newCoin.transform.SetParent(coinCounter.transform);
        newCoin.GetComponent<CoinMove>().moveTarget = coinImage.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GrassBlock")
        {
            Debug.Log("SellCheck");
            backPack.SellBlock(other.gameObject);
            GetCoin();
        }
    }
}
