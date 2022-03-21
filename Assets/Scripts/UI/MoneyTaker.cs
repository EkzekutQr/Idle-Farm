using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTaker : MonoBehaviour
{
    [SerializeField]
    private GameObject coinsCounter;

    private void AddMoney()
    {
        int coinCount = int.Parse(coinsCounter.GetComponent<Text>().text);
        coinCount++;
        coinsCounter.GetComponent<Text>().text = coinCount.ToString();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            Debug.Log("CoinCollisionCheck");
            Destroy(collision.gameObject);
            AddMoney();
        }
    }
}
