using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackBehavior : MonoBehaviour
{
    [SerializeField]
    private int backPackSize = 40;

    [SerializeField]
    List<GameObject> blocks;

    private void PickUpBlock(GameObject block)
    {
        if (blocks.Count < backPackSize)
        {
            if(block.GetComponent<GrassBlockBehavior>().isCollected == false)
            {
                blocks.Add(block);
                block.GetComponent<GrassBlockBehavior>().isCollected = true;
                block.transform.SetParent(gameObject.transform);
                if(blocks.Count == 1)
                {
                    block.transform.localPosition = Vector3.zero;
                }
                else
                {
                    block.transform.localPosition = Vector3.zero + new Vector3(0, 0.0415f * (blocks.Count - 1), 0);
                }
                block.transform.rotation = gameObject.transform.rotation;
                Destroy(block.GetComponent<BoxCollider>());
                Destroy(block.GetComponent<Rigidbody>());
            }
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
