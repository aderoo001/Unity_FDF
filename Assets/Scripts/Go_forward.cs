using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go_forward : MonoBehaviour
{
    private GameObject go;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = go.transform;
        t.position = new Vector3(t.position.x, t.position.y,t.position.z + speed);
    }
}
