using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ARObjectPlacer : MonoBehaviour
{
    public List<GameObject> objectToPlace = new List<GameObject>();
    public Transform spawn;

    public GameObject redBoard;
    public GameObject blueBoard;

    private bool redActive;
    private bool blueActive;

    private bool canShoot;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private bool ballActive;

    private float currentTime;
    private float startTime = 30f;
    

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        redActive = false;
        blueActive = false;
        ballActive = false;

        canShoot = true;

        currentTime = startTime;
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

            if (canShoot == true)
            {
                if (redActive == false)
                {
                    Instantiate(redBoard, pose.position, pose.rotation);
                    redActive = true;
                    StartCoroutine(HoldUp());
                }

                if (redActive == true && blueActive == false)
                {
                    Instantiate(blueBoard, pose.position, pose.rotation);
                    blueActive = true;
                    StartCoroutine(HoldUp());
                }

                else if (ballActive == false)
                {
                    Instantiate(objectToPlace[Random.Range(0, objectToPlace.Count)], spawn.position, spawn.rotation);
                    ballActive = true;
                    StartCoroutine(HoldUp());
                }
            }

            canShoot = true;

        }
    }

    IEnumerator HoldUp()
    {
        ballActive = false;
        canShoot = false;
        yield return new WaitForSeconds(2);
    }
}