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
    private GameObject b1;
    private GameObject r1;

    private bool redActive;
    private bool blueActive;

    private bool canShoot;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private bool ballActive;

    private float currentTime;
    private float startTime = 30f;

    [SerializeField] Text timer;
    [SerializeField] GameObject gameOverPopup;
    [SerializeField] GameObject winPopup;
    

    private void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        redActive = false;
        blueActive = false;
        ballActive = false;

        canShoot = true;

        currentTime = startTime;

        gameOverPopup.SetActive(false);
        winPopup.SetActive(false);
    }


    private void Update()
    {
        GameState();

        if(blueActive == true)
        {
            currentTime -= Time.deltaTime;
        }

        timer.text = currentTime.ToString("0");

        if (Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);

        if(raycastManager.Raycast(touch.position, hits) && touch.phase == TouchPhase.Began)
        {
            Pose pose = hits[0].pose;

            if (canShoot == true)
            {
                if (redActive == false)
                {
                    Instantiate(redBoard, pose.position, pose.rotation);
                    redActive = true;
                    winPopup.SetActive(false);
                    StartCoroutine(HoldUp());
                }

                else if (redActive == true && blueActive == false)
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

    private void GameState()
    {

        if(currentTime <= 0)
        {
            currentTime = 0;
            gameOverPopup.SetActive(true);
        }

        b1 = GameObject.FindGameObjectWithTag("Blue");
        r1 = GameObject.FindGameObjectWithTag("Red");

        if(b1 == null && r1 == null)
        {
            winPopup.SetActive(true);
        }

    }
    
}