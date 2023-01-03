using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_drone : MonoBehaviour
{
    public float speed = 10.0f;
    float smooth = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + speed, transform.rotation.eulerAngles.z);
        transform.rotation =Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    }
}
