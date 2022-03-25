using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackBehavior : MonoBehaviour
{
    [SerializeField]
    private int backPackSize = 40;

    [SerializeField]
    private List<GameObject> blocks;

    public int coins = 0;

    private int blockIndex;

    [SerializeField]
    GameObject dropTarget;

    [SerializeField]
    GameObject backPackCouner;

    public List<GameObject> Blocks { get => blocks; set => blocks = value; }

    private void Update()
    {
        backPackCouner.GetComponent<Text>().text = Blocks.Count.ToString() + "/" + backPackSize.ToString();
    }
    private void PickUpBlock(GameObject block)
    {
        if (Blocks.Count < backPackSize)
        {
            if (block.GetComponent<GrassBlockBehavior>().IsCollected == false)
            {
                block.transform.SetParent(gameObject.transform.GetChild(transform.childCount - (Blocks.Count % transform.childCount) - 1));

                block.GetComponent<GrassBlockBehavior>().CollectedSwitch(Blocks.Count, true);

                Blocks.Add(block);
            }
        }
    }
    public IEnumerator DropBlockCourutine()
    {
        for (blockIndex = (Blocks.Count - 1); blockIndex >= 0; blockIndex--)
        {
            DropBlockLogic();

            yield return new WaitForSeconds(0.1f);
        }
    }
    private void DropBlockLogic()
    {
        Blocks[blockIndex].transform.SetParent(null);
        Blocks[blockIndex].GetComponent<GrassBlockBehavior>().DropBlockSwitch(true, dropTarget);
    }

    public void SellBlock(GameObject block)
    {
        if (Blocks.Count > 0)
        {
            Blocks.Remove(block);
            Destroy(block);
            coins++;
            Debug.Log(Blocks.Count);
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
