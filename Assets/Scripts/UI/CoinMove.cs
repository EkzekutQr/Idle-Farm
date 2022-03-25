using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField]
    private int speed = 50;

    public Transform moveTarget;

    public int grassPrice;

    void Update()
    {
        if(moveTarget != null)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, moveTarget.position, speed);
        }
    }
}
