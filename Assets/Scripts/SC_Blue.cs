using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Blue : MonoBehaviour
{
    MeshRenderer rend;
    bool isVisible = true;
    public float distanceToReveal = 0.2f;
    public float distanceToPlayer;
    

    private void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (distanceToPlayer <= distanceToReveal)
        {
            if (isVisible)
                SetVisible(true);
        }
        else if (isVisible)
        {
            SetVisible(false);
        }
    }

    void SetVisible(bool set)
    {
        isVisible = set;
        rend.enabled = set;
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Ball"))
        {
            Destroy(gameObject);
        }
    }
}