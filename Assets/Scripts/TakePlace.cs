using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlace : MonoBehaviour
{
    private GameObject go;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        go = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Transform t = go.transform;
        t.position = new Vector3(t.position.x  - speed, t.position.y,t.position.z);
        t.rotation = Quaternion.Euler(0, 0, 15);
    }
}
