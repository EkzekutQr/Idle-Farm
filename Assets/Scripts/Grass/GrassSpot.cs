using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpot : MonoBehaviour
{
    [SerializeField]
    private GameObject grassPrefab;

    [SerializeField]
    private float growGrassTimeDelay;

    public void GetGrowNewGrass()
    {
        Invoke("CreateNewGrass", growGrassTimeDelay);
    }
    private void CreateNewGrass()
    {
        GameObject newGrass = Instantiate(grassPrefab);
        newGrass.transform.SetParent(gameObject.transform);
        newGrass.transform.localPosition = new Vector3(0, -50, 0);
    }
}
