using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ARObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectToPlace = new List<GameObject>();
    public GameObject gameBoard;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool boardActive;
    private bool ballActive;

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        boardActive = false;
        ballActive = false;
    }

    private void Update()
    {
        Pose pose = hits[0].pose;

        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if(raycastManager.Raycast(touch.position, hits))
        {
            if(boardActive == false)
            {
                Instantiate(gameBoard, pose.position, pose.rotation);
                boardActive = true;
            }
            else if (ballActive == false)
            {
                Instantiate(objectToPlace[Random.Range(0, objectToPlace.Count)], pose.position, pose.rotation);
                ballActive = true;
                Invoke("Reset", 3);
            }
        }
    }

    private void Reset()
    {
        ballActive = false;
    }
}