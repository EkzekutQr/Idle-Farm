using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlockBehavior : MonoBehaviour
{
    public bool isCollected = false;

    public bool isBlockDrop = false;

    private float blockFlySpeed = 1;

    [SerializeField]
    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("DropPoint");
    }
    private void FixedUpdate()
    {
        if (isBlockDrop)
        {
            DropBlock();
        }
    }
    private void DropBlock()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, blockFlySpeed);
    }
}
