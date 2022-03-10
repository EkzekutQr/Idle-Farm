﻿using UnityEngine;
using EzySlice;
public class Slicer : MonoBehaviour
{
    public Material materialAfterSlice;
    public LayerMask sliceMask;
    public bool isTouched;

    private void Update()
    {
        if (isTouched == true)
        {
            isTouched = false;

            Collider[] objectsToBeSliced = Physics.OverlapBox(transform.position, new Vector3(1, 0.1f, 0.1f), transform.rotation, sliceMask);
            
            foreach (Collider objectToBeSliced in objectsToBeSliced)
            {

                SlicedHull slicedObject = SliceObject(objectToBeSliced.gameObject, materialAfterSlice);


                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);


                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                upperHullGameobject.transform.localScale = objectToBeSliced.transform.lossyScale;
                upperHullGameobject.transform.rotation = objectToBeSliced.transform.rotation;
                upperHullGameobject.layer = 8;
                upperHullGameobject.gameObject.GetComponent<Rigidbody>().AddForce(objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);
                upperHullGameobject.AddComponent<SlicedObjectDestroy>();



                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.localScale = objectToBeSliced.transform.lossyScale;
                lowerHullGameobject.transform.rotation = objectToBeSliced.transform.rotation;
                lowerHullGameobject.layer = 8;
                lowerHullGameobject.AddComponent<SlicedObjectDestroy>();

                Destroy(objectToBeSliced.gameObject);
            }
        }
    }

    private void MakeItPhysical(GameObject obj)
    {
        obj.AddComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
    }

    private SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.up, crossSectionMaterial);
    }


}
