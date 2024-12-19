using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class present : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.5f; // How high/low it hovers
    [SerializeField] private float speed = 2f;       // How fast it hovers

    private Vector3 startPosition;

    void Start()
    {
        // Record the initial position so we hover around it
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate new Y offset using a sine wave
        float offset = Mathf.Sin(Time.time * speed) * amplitude;
        
        // Update the transform's position
        transform.position = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);
    }
}
