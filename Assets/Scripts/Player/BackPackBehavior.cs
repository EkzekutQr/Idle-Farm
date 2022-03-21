using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackBehavior : MonoBehaviour
{
    [SerializeField]
    private int backPackSize = 40;

    [SerializeField]
    private List<GameObject> blocks;

    public int coins = 0;

    [SerializeField]
    private float blockFlySpeed = 1;

    private int blockIndex;

    private void PickUpBlock(GameObject block)
    {
        if (blocks.Count < backPackSize)
        {
            if (block.GetComponent<GrassBlockBehavior>().isCollected == false)
            {
                blocks.Add(block);
                block.GetComponent<GrassBlockBehavior>().isCollected = true;
                block.transform.SetParent(gameObject.transform);
                if (blocks.Count == 1)
                {
                    block.transform.localPosition = Vector3.zero;
                }
                else
                {
                    block.transform.localPosition = Vector3.zero + new Vector3(0, 0.0415f * (blocks.Count - 1), 0);
                }
                block.transform.rotation = gameObject.transform.rotation;
                //Destroy(block.GetComponent<BoxCollider>());
                Destroy(block.GetComponent<Rigidbody>());
            }
        }
    }
    public void DropBlock()
    {
        //for (blockIndex = (blocks.Count - 1); blockIndex > 0; blockIndex--)
        //{
        //    Debug.Log(blockIndex);
        //    Debug.Log(blocks.Count);
        //    Invoke("DropBlockLogic", 1f);
        //}
    }
    public IEnumerator DropBlockCourutine()
    {
        for (blockIndex = (blocks.Count - 1); blockIndex >= 0; blockIndex--)
        {
            DropBlockLogic();

            yield return new WaitForSeconds(0.1f);
        }
    }
    public void DropBlockLogic()
    {
        blocks[blockIndex].transform.SetParent(null);
        blocks[blockIndex].GetComponent<GrassBlockBehavior>().isBlockDrop = true;
    }

    public void SellBlock(GameObject block)
    {
        if (blocks.Count > 0)
        {
            blocks.Remove(block);
            Destroy(block);
            coins++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrassBlock")
        {
            PickUpBlock(other.gameObject);
        }
    }
}
