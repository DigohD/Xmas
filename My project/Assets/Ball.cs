using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float minRotationSpeed = 200f;
    [SerializeField] private float maxRotationSpeed = 1000f;
    private float rotationSpeed;
    
    void Start()
    {
        // Choose a random rotation speed when the object starts
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        int presentLayer = LayerMask.NameToLayer("Present");
        int terrainLayer = LayerMask.NameToLayer("Terrain");

        if (other.gameObject.layer == presentLayer)
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.layer == terrainLayer)
        {
            GameManager.Instance.TriggerSpawn();
            Destroy(gameObject);
        }
    }
}
