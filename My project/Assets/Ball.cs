using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    /void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object we collided with is the cannonball (by tag)

        // Destroy this game object
        Destroy(gameObject);
        // This won't physically affect the cannonball since we're just removing this object
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object we collided with is the cannonball (by tag)
        {
            // Destroy this game object
            Destroy(gameObject);
            // This won't physically affect the cannonball since we're just removing this object
    }
    
}
