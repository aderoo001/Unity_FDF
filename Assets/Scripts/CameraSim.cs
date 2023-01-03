using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSim : MonoBehaviour
{
    Camera maCamera;
    Camera maCamera2;

    MeshFilter meshFilter;
    MeshRenderer meshRenderer;

    void Start()
    {
        GameObject cameraObject = GameObject.Find("Camera_infrarouge");
        maCamera = cameraObject.GetComponent<Camera>();
        maCamera.enabled = false;

        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Ray ray = maCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        float fieldOfView = maCamera.fieldOfView;
        float aspectRatio = maCamera.aspect;
        float distanceMax = 100;

        int nbSommets = 32;
        float angleMax = fieldOfView * Mathf.Deg2Rad;
        float angleStep = angleMax / (nbSommets - 1);
        Vector3[] sommets = new Vector3[nbSommets + 1];
        for (int i = 0; i < nbSommets; i++)
        {
            float angle = angleStep * i - angleMax;
            float distance = distanceMax / Mathf.Tan(angleMax / 2);
            Vector3 direction = Quaternion.Euler(0, -angle * Mathf.Rad2Deg, 0) * ray.direction;
            sommets[i] = ray.origin + direction * distance;
        }
        sommets[nbSommets] = ray.origin;

        int[] triangles = new int[nbSommets * 3];
        for (int i = 0; i < nbSommets; i++)
        {
            triangles[i * 3] = nbSommets;
            triangles[i * 3 + 1] = i;
            triangles[i * 3 + 2] = (i + 1) % nbSommets;
        }

        Mesh mesh = new Mesh();
        mesh.vertices = sommets;
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;

        maCamera2 = Camera.main;
        maCamera2.cullingMask |= 1 << gameObject.layer;
    }
}
