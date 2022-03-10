using UnityEngine;
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

                materialAfterSlice = objectToBeSliced.gameObject.GetComponent<MeshRenderer>().material;

                GameObject upperHullGameobject = slicedObject.CreateUpperHull(objectToBeSliced.gameObject, materialAfterSlice);
                GameObject lowerHullGameobject = slicedObject.CreateLowerHull(objectToBeSliced.gameObject, materialAfterSlice);

                MakeItPhysical(upperHullGameobject);
                MakeItPhysical(lowerHullGameobject);

                upperHullGameobject.transform.position = objectToBeSliced.transform.position;
                upperHullGameobject.transform.localScale = objectToBeSliced.transform.lossyScale;
                upperHullGameobject.transform.rotation = objectToBeSliced.transform.rotation;
                //upperHullGameobject.layer = objectToBeSliced.gameObject.layer;
                upperHullGameobject.layer = 8;
                upperHullGameobject.gameObject.GetComponent<MeshRenderer>().material = objectToBeSliced.gameObject.GetComponent<MeshRenderer>().material;
                upperHullGameobject.gameObject.GetComponent<Rigidbody>().AddForce(objectToBeSliced.gameObject.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);



                lowerHullGameobject.transform.position = objectToBeSliced.transform.position;
                lowerHullGameobject.transform.localScale = objectToBeSliced.transform.lossyScale;
                lowerHullGameobject.transform.rotation = objectToBeSliced.transform.rotation;
                //lowerHullGameobject.layer = objectToBeSliced.gameObject.layer;
                lowerHullGameobject.layer = 8;
                lowerHullGameobject.gameObject.GetComponent<MeshRenderer>().material = objectToBeSliced.gameObject.GetComponent<MeshRenderer>().material;
                lowerHullGameobject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                materialAfterSlice = null;

                //MakeItPhysical(upperHullGameobject);
                //MakeItPhysical(lowerHullGameobject);

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
