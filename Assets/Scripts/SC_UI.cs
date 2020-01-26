using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_UI : MonoBehaviour
{
    public Text player1Info;
    public GameObject player2Button;

    public float currentTime;
    private float startTime = 30f;

    [SerializeField] Text timer;

    private bool go;

    // Start is called before the first frame update
    void Start()
    {
        go = false;
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = currentTime.ToString("0");

        if(go == true)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public void SwapPhone()
    {
        Destroy(player1Info);
        player2Button.SetActive(false);
        go = true;
    }


}