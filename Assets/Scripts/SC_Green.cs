using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Green : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Green"))
        {
            Destroy(gameObject);
        }
    }
}
