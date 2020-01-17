using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ARObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectToPlace = new List<GameObject>();
    public Transform spawn;

    public GameObject redBoard;
    public GameObject greenBoard;
    public GameObject blueBoard;
    public GameObject yellowBoard;

    private bool redActive;
    private bool greenActive;
    private bool blueActive;
    private bool yellowActive;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private bool ballActive;

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        redActive = false;
        blueActive = false;
        greenActive = false;
        yellowActive = false;
        ballActive = false;
    }

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if(raycastManager.Raycast(touch.position, hits))
        {
            Pose pose = hits[0].pose;

            if (redActive == false)
            {
                Instantiate(redBoard, pose.position, pose.rotation);
                redActive = true;
                return;
            }
            else if (blueActive == false)
            {
                Instantiate(blueBoard, pose.position, pose.rotation);
                blueActive = true;
                return;
            }
            else if (greenActive == false)
            {
                Instantiate(greenBoard, pose.position, pose.rotation);
                greenActive = true;
                return;
            }
            else if (yellowActive == false)
            {
                Instantiate(yellowBoard, pose.position, pose.rotation);
                yellowActive = true;
                return;
            }

            else if (ballActive == false)
            {
                Instantiate(objectToPlace[Random.Range(0, objectToPlace.Count)], spawn.position, spawn.rotation);
                ballActive = true;
                Invoke("Reset", 1);
            }
        }
    }

    private void Reset()
    {
        ballActive = false;
    }
}