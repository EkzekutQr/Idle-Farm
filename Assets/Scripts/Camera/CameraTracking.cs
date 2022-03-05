using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject _camera;

    [SerializeField]
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            _camera.transform.position = player.transform.position + cameraPosition;
            gameObject.transform.LookAt(player.transform);
        }
    }
}
