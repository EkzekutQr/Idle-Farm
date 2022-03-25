using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBlockBehavior : MonoBehaviour
{
    private bool isCollected = false;

    private bool isBlockDrop = false;

    private float blockFlySpeed = 1;

    private int blocksCount;

    private GameObject target;

    [SerializeField]
    private int blockPrice;

    public bool IsCollected { get => isCollected; private set => isCollected = value; }
    public bool IsBlockDrop { get => isBlockDrop; private set => isBlockDrop = value; }
    public int BlockPrice { get => blockPrice; private set => blockPrice = value; }

    private void FixedUpdate()
    {
        if (IsBlockDrop)
        {
            DropBlock();
        }
        if (IsCollected)
        {
            if (!IsBlockDrop)
                CollectBlock();
        }
    }
    private void DropBlock()
    {
        transform.SetParent(null);

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, blockFlySpeed);
    }
    private void CollectBlock()
    {
        Destroy(gameObject.GetComponent<Rigidbody>());

        gameObject.GetComponent<BoxCollider>().isTrigger = true;

        transform.rotation = transform.parent.rotation;

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero + new Vector3(0, 0.0415f * (blocksCount / 4), 0), 1);
    }
    public void CollectedSwitch(int blocksCount, bool state)
    {
        IsCollected = state;

        this.blocksCount = blocksCount;
    }
    public void DropBlockSwitch(bool state, GameObject target)
    {
        IsBlockDrop = state;

        this.target = target;
    }
}
