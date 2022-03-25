using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyTaker : MonoBehaviour
{
    [SerializeField]
    private GameObject coinsCounter;

    private void AddMoney(int grassPrice)
    {
        gameObject.transform.DOShakePosition(0.5f, 10, 10, 90, false, false);
        int coinCount = int.Parse(coinsCounter.GetComponent<Text>().text);
        coinCount = coinCount + grassPrice;
        coinsCounter.GetComponent<Text>().text = coinCount.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            AddMoney(collision.gameObject.GetComponent<CoinMove>().grassPrice);
            Destroy(collision.gameObject);
        }
    }
}
