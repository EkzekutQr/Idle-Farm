using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedObjectDestroy : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(100, -100), Random.Range(100, -100), Random.Range(100, -100), ForceMode.Impulse);
        Invoke("DestroyThisObject", 2f);
    }
    private void DestroyThisObject()
    {
        Destroy(gameObject);
    }
}
