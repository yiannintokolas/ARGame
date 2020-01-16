using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class ARObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectToPlace = new List<GameObject>();
    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    private void Update()
    {
        if(Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if(raycastManager.Raycast(touch.position, hits))
        {
            Pose pose = hits[0].pose;

            Instantiate(objectToPlace[Random.Range(0, objectToPlace.Count)], pose.position, pose.rotation);
        }
    }
}