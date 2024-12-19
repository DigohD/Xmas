using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PresentPrefab;
    public GameObject KatapultPrefab;
    // -9 -> 9 width
    // -2 -> 4 height

    public float minX = -9.0f;
    public float maxX = 9.0f;
    public float minY = -2.0f;
    public float maxY = 2.0f;
    
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    
    private bool isSpawning = false;
    
    void SpawnPresent()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
        
        Instantiate(PresentPrefab, randomPosition, Quaternion.identity);
    }
    
    public void TriggerSpawn()
    {
        if (!isSpawning)
        {
            var katapultRef = GameObject.FindGameObjectWithTag("Katapult");
            Destroy(katapultRef);
            Instantiate(KatapultPrefab, new Vector3(-9.0f, -3.4f, 0.0f), Quaternion.identity);
            StartCoroutine(SpawnAtRandomIntervals());
        }
    }
    
    IEnumerator SpawnAtRandomIntervals()
    {
        isSpawning = true;
        
        float randomWaitTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(randomWaitTime);
        
        SpawnPresent();

        isSpawning = false; 
    }
    
    
    void Start()
    {
        TriggerSpawn();
    }

    void Update()
    {
        
    }
}
