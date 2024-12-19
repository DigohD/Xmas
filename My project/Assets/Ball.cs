using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public CameraShake cameraShake; // Reference to the CameraShake script
    public float shakeDuration = 0.3f; // Duration of the shake
    public float shakeMagnitude = 0.1f;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        int presentLayer = LayerMask.NameToLayer("Present");
        int terrainLayer = LayerMask.NameToLayer("Terrain");

        if (other.gameObject.layer == presentLayer)
        {
            Destroy(other.gameObject);
            cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
            StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
        }else if (other.gameObject.layer == terrainLayer)
        {
            GameManager.Instance.TriggerSpawn();
            Destroy(gameObject);
        }
    }
}
