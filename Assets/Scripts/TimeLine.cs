using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLine : MonoBehaviour
{
    private int time = 0;
    private bool isRunning = false;

    public GameObject go;

    public GameObject title;
    public GameObject mission;
    public GameObject spitch;
    public GameObject drone;
    public GameObject image;
    public GameObject voilure;
    public GameObject energy;
    public GameObject moduleCam;
    public GameObject moduleCom;
    public GameObject camInfra;
    public GameObject dronePOV;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        go = Instantiate(go) as GameObject;
        go.name = "GO_pres";
    }

    IEnumerator waiter()
    {
        isRunning = true;
        Debug.Log(time);

        if (time == 1) {
            drone = Instantiate(drone) as GameObject;
            drone.GetComponent<Go_forward>().enabled = false;
            Transform t = drone.GetComponent<Transform>();
            t.position = new Vector3(6, 2, 0);
            t.rotation = Quaternion.Euler(0, 45, -45);
            go = GameObject.Find("Canvas_pres");
            title = Instantiate(title, go.transform) as GameObject;
            //image = Instantiate(image, go.transform) as GameObject;
        } 
        else if (time == 3) mission = Instantiate(mission, go.transform) as GameObject;
        else if (time == 8) spitch = Instantiate(spitch, go.transform) as GameObject;
        else if (time == 16) {
            Destroy(mission);
            Destroy(spitch);
        }
        else if (time == 17) {
            drone.GetComponent<Rotation_drone>().enabled = false;
            Transform t = drone.GetComponent<Transform>();
            t.position = Vector3.zero;
            t.rotation = Quaternion.Euler(0, 90, 25);
        }
        else if (time == 18) moduleCam = Instantiate(moduleCam, go.transform) as GameObject;
        else if (time == 19) moduleCom = Instantiate(moduleCom, go.transform) as GameObject;
        else if (time == 20) energy = Instantiate(energy, go.transform) as GameObject;
        else if (time == 21) voilure = Instantiate(voilure, go.transform) as GameObject;
        else if (time == 24) {
            Destroy(title);
            Destroy(moduleCam);
            Destroy(moduleCom);
            Destroy(energy);
            Destroy(voilure);
        }
        else if (time == 25) {
            drone.GetComponent<Go_forward>().enabled = true;
            go = GameObject.Find("GO_pres");
            Destroy(go);
            Transform t = drone.GetComponent<Transform>();
            t.position = new Vector3(980,2200,980);
            t.rotation = Quaternion.Euler(0, 0, 0);
            GameObject cam = new GameObject("cam");
            Camera camera = cam.AddComponent<Camera>();
            camera.name = "cam";
            camera.tag = "MainCamera";
            cam.transform.SetParent(GameObject.Find("Cam1").transform);
            cam.transform.localPosition = Vector3.zero;
            cam.transform.localRotation = Quaternion.identity;
            go = GameObject.Find("Module optronique");
            camInfra = Instantiate(camInfra, go.transform) as GameObject;
            camInfra.transform.localPosition = Vector3.zero;
            camInfra.transform.localRotation = Quaternion.identity;
            dronePOV = Instantiate(dronePOV, go.transform) as GameObject;
        } else if (time == 35) {
            Destroy(drone);
        }

        time = time+1;
        yield return new WaitForSeconds(1.0f);
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) StartCoroutine(waiter());
    }
}