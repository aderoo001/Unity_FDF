using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject go;
    public float speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = go.transform;
        t.position = new Vector3(t.position.x + 2*speed, t.position.y,t.position.z + speed/2);
    }
}
