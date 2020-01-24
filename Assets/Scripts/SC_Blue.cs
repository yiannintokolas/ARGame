using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Blue : MonoBehaviour
{
    public GameObject board;


    private void Start()
    {
        board.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            board.SetActive(true);
        }
        else
        {
            board.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ball"))
        {
            Destroy(gameObject);
        }
    }


}