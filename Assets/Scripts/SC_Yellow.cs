using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Yellow : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Yellow"))
        {
            Destroy(gameObject);
        }
    }
}
