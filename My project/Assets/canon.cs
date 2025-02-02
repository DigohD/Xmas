using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{
    [SerializeField] private float chargeRate = 50f; // Increase this value to charge faster
    [SerializeField] private float maxPower = 100f;
   
    public CameraShake cameraShake; // Reference to the CameraShake script
    public float shakeDuration = 0.3f; // Duration of the shake
    public float shakeMagnitude = 0.1f;

    public GameObject ball;
    
    public float currentPower = 0f;
    private bool isCharging = false;

    public ParticleSystem FireEffect;

    private bool hasFired = false;
    
    void Update()
    {
        if (!GameManager.FiringAllowed)
            return;
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start charging
            isCharging = true;
            currentPower = 0f; // Reset power each time you start charging
        }
        
        // If charging and space still held down
        if (GameManager.FiringAllowed && !hasFired && isCharging && Input.GetKey(KeyCode.Space))
        {
            // Increase power over time, clamping to maxPower
            currentPower += chargeRate * Time.deltaTime;
            currentPower = Mathf.Min(currentPower, maxPower);

            // If power reached max, release charge and fire automatically
            if (currentPower >= maxPower)
            {
                ReleasePower();
            }
        }

        // If charging and spacebar is released this frame
        if (GameManager.FiringAllowed &&!hasFired && isCharging && Input.GetKeyUp(KeyCode.Space))
        {
            ReleasePower();
        }

        powerUi.power = currentPower;
    }

    private void ReleasePower()
    {
        isCharging = false;
        Fire(currentPower);
    }

    private void Fire(float powerValue)
    {
        hasFired = true;
        // Implement what happens when you fire with the given power
        Debug.Log("Fired with power: " + powerValue);
        // For example, instantiate a projectile, apply force, etc.

        if (!ball)
            return;
        
        ball.transform.SetParent(null);
        ball.SetActive(true);
        ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * powerValue * 10);
        GetComponent<AudioSource>().Play();
        
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        StartCoroutine(cameraShake.Shake(shakeDuration, shakeMagnitude));
        
        FireEffect.Play();
        
        Destroy(this);
    }
}
