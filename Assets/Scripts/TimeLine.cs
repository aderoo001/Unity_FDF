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
    public GameObject essaims;
    public GameObject border;
    public GameObject fire;
    public GameObject image;
    public GameObject voilure;
    public GameObject energy;
    public GameObject navigation;
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

    void setCameras()
    {
        GameObject cam = new GameObject("cam");
        Camera camera = cam.AddComponent<Camera>();
        camera.name = "cam";
        camera.tag = "MainCamera";

        Transform cam1Trans = GameObject.Find("Cam1").transform;
        cam.transform.SetParent(cam1Trans);

        cam.transform.localPosition = Vector3.zero;
        cam.transform.localRotation = Quaternion.identity;


        go = GameObject.Find("Module optronique");
        camInfra = Instantiate(camInfra, go.transform) as GameObject;
        camInfra.transform.localPosition = Vector3.zero;
        camInfra.transform.localRotation = Quaternion.identity;
        dronePOV = Instantiate(dronePOV, go.transform) as GameObject;
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
        else if (time == 19) voilure = Instantiate(voilure, go.transform) as GameObject;
        else if (time == 21) energy = Instantiate(energy, go.transform) as GameObject;
        else if (time == 23) moduleCom = Instantiate(moduleCom, go.transform) as GameObject;
        else if (time == 25) navigation = Instantiate(navigation, go.transform) as GameObject;
        else if (time == 27) moduleCam = Instantiate(moduleCam, go.transform) as GameObject;
        else if (time == 29) {
            Destroy(title);
            Destroy(moduleCam);
            Destroy(energy);
            Destroy(voilure);
            Destroy(navigation);
            Destroy(moduleCom);
        }
        else if (time == 31) {
            drone.GetComponent<Go_forward>().enabled = true;

            // Destroy text
            go = GameObject.Find("GO_pres");
            Destroy(go);

            Transform t = drone.GetComponent<Transform>();
            t.position = new Vector3(980, 2200, 0);
            t.rotation = Quaternion.Euler(0, 0, 0);

            setCameras();
        }

        else if (time == 46) {  
            fire = Instantiate(fire) as GameObject;
            Transform fireTrans = fire.GetComponent<Transform>();
            fireTrans.position = new Vector3(980, 2110, 616);
            fireTrans.localScale = new Vector3(254, 209, 452);
        }

        else if (time == 51) {  
            drone.GetComponent<Go_forward>().enabled = false;

            border = Instantiate(border) as GameObject;
            RectTransform t = border.GetComponent<RectTransform>();
            t.rotation = Quaternion.Euler(-87.2f, -17.5f, -10.06f);
            t.position = new Vector3(992, 2126, 613);
        }

        else if (time == 55) 
        {
            Destroy(dronePOV);
            Destroy(camInfra);
            essaims = Instantiate(essaims) as GameObject;
        }

        else if (time == 65)
        {
            // Blink and destroy
            GameObject drone_3 = GameObject.Find("Drone_3");
            for (int i = 0; i<5; i++)
            { 
                drone_3.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                drone_3.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
            Destroy(drone_3);
        }

        else if (time == 70)
        {
            GameObject drone_4 = GameObject.Find("Drone_4");
            GameObject drone_5 = GameObject.Find("Drone_5");
            drone_4.GetComponent<TakePlace>().enabled = true;
            drone_5.GetComponent<TakePlace>().enabled = true;
            yield return new WaitForSeconds(2.1f);
            drone_4.GetComponent<TakePlace>().enabled = false;
            drone_5.GetComponent<TakePlace>().enabled = false;
        }

        else if (time == 90)
        {
            foreach (GameObject o in Object.FindObjectsOfType<GameObject>()) 
            {
                Destroy(o);
            }
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