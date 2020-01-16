using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Red : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Red"))
        {
            Destroy(gameObject);
        }
    }

}
