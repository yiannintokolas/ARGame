using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Blue : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Blue"))
        {
            Destroy(gameObject);
        }
    }
}
