using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ShootBall : MonoBehaviour
{
    private Rigidbody rb;
    private float force = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Shoot();
    }

    private void Shoot()
    {
        rb.AddRelativeForce(0, 0, force, ForceMode.Impulse);
    }
}
