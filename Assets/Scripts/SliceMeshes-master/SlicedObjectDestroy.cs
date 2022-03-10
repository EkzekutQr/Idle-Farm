using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedObjectDestroy : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyThisObject", 2f);
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
