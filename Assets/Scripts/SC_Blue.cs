using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Blue : MonoBehaviour
{
    public Renderer board;


    private void Start()
    {
        board = GetComponent<Renderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Player"))
        {
            board.enabled = true;
        }
        else
        {
            board.enabled = false;
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