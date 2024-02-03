using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float accel = DataHandler.Instance.ballAccel;
    private float max = DataHandler.Instance.maxballSpeed;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (accel == 0.0f)
        {
            accel = 0.01f;
        }
        if (max == 0.0f)
        {
            max = 3.0f;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.velocity;
        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * accel;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        //max velocity
        if (velocity.magnitude > max)
        {
            velocity = velocity.normalized * max;
        }

        m_Rigidbody.velocity = velocity;
    }
}
