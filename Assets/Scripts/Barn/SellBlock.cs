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

    private void GetCoin(int grassPrice)
    {
        GameObject newCoin = Instantiate(coin);
        newCoin.transform.position = coinSpawnPoint.transform.position;
        newCoin.transform.SetParent(coinCounter.transform);
        newCoin.GetComponent<CoinMove>().moveTarget = coinImage.transform;
        newCoin.GetComponent<CoinMove>().grassPrice = grassPrice;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GrassBlock")
        {
            backPack.SellBlock(other.gameObject);
            GetCoin(other.gameObject.GetComponent<GrassBlockBehavior>().BlockPrice);
        }
    }
}
