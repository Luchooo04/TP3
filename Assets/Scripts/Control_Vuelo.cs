using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Vuelo : Controller_Player
{
    public float flySpeed = 10f; // the speed at which the character can fly

    private Rigidbody rb; // the Rigidbody component of the character

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Move the character up when the spacebar is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * flySpeed, ForceMode.Acceleration);
        }
    }
}
