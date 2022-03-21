using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBlock : MonoBehaviour
{
    [SerializeField]
    BackPackBehavior backPack;

    [SerializeField]
    private Transform dropTarget;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
           backPack.StartCoroutine(backPack.DropBlockCourutine());
        }
    }
}
