using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed = 200f;
    [SerializeField] private float maxRotationSpeed = 1000f;
    private float rotationSpeed;

    public GameObject DeathEffect;
    
    void Start()
    {
        // Choose a random rotation speed when the object starts
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    
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

            // Instantiate the DeathEffect
            var effectInstance = Instantiate(DeathEffect, other.transform.position, Quaternion.identity);

            // Check if the name of the object hit has "Skull"
            if (other.gameObject.name.Contains("Skull"))
            {
                // Get the ParticleSystem component from the instantiated effect
                ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    var main = ps.main;
                    // Set the start color to a gradient from Red to Black
                    main.startColor = new ParticleSystem.MinMaxGradient(Color.red, Color.black);
                }
            }
        }
        else if (other.gameObject.layer == terrainLayer)
        {
            GameManager.Instance.TriggerSpawn();
            Destroy(gameObject);
        }
    }
}
