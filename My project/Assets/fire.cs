using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float minAngle = 10f;
    [SerializeField] private float maxAngle = 90f;

    void Update()
    {
        // Calculate an angle that moves back and forth between minAngle and maxAngle
        float angle = Mathf.PingPong(Time.time * rotationSpeed, maxAngle - minAngle) + minAngle;

        // Apply the rotation around the Z-axis (typical for 2D)
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this);
        }
    }
}
