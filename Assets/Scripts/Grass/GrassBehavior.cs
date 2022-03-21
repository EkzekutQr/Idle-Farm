using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject grassBlock;
    public void DestroyGrass()
    {
        Instantiate(grassBlock, gameObject.transform.position + new Vector3(0 , 5, 0), Quaternion.identity);
        Destroy(gameObject);
    }
}
