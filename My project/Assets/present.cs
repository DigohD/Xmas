using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class present : MonoBehaviour
{
    // If using OnTriggerEnter2D, ensure the target object's collider is marked as "Is Trigger".
    // Also, the cannonball needs a Rigidbody2D for trigger events to occur reliably.
    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the object we collided with is the cannonball (by tag)

            // Destroy this game object
            Destroy(gameObject);
            // This won't physically affect the cannonball since we're just removing this object
        
    }
}
