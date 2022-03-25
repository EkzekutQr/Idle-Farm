using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject grassBlock;

    [SerializeField]
    private float growSpeed;

    public void DestroyGrass()
    {
        if (transform.parent != null)
        {
            transform.parent.GetComponent<GrassSpot>().GetGrowNewGrass();
        }

        if (grassBlock != null)
        {
            Instantiate(grassBlock, gameObject.transform.position + new Vector3(0, 5, 0), Quaternion.identity);
        }

        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        Grow();
    }
    private void Grow()
    {
        if (transform.localPosition.y < 45)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 45, 0), growSpeed / 10);
        }
    }
}
