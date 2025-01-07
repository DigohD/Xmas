using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public GameObject PresentPrefab;
    public GameObject SkullPresentPrefab;
    public GameObject KatapultPrefab;
    // -9 -> 9 width
    // -2 -> 4 height

    public float minX = -9.0f;
    public float maxX = 9.0f;
    public float minY = -2.0f;
    public float maxY = 2.0f;
    
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;
    
    public float minPresentScale = 0.25f;
    public float maxPresentScale = 1.65f;
    
    private bool isSpawning = false;

    public static bool FiringAllowed;
    
    void Awake()
    {
        Instance = this;
    }
    
    void SpawnPresent(GameObject prefab)
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
        
        var obj = Instantiate(prefab, randomPosition, Quaternion.identity);

        float randomScale = Random.Range(minPresentScale, maxPresentScale);

        obj.transform.localScale *= randomScale;
    }
    
    public void TriggerSpawn()
    {
        if (!isSpawning)
        {
            var katapultRef = GameObject.FindGameObjectWithTag("Katapult");
            Destroy(katapultRef);
            var allPresents = GameObject.FindGameObjectsWithTag("Present");
            foreach (var present in allPresents)
            {
                Destroy(present);
            }
            Instantiate(KatapultPrefab, new Vector3(-9.0f, -3.4f, 0.0f), Quaternion.identity);
            StartCoroutine(SpawnAtRandomIntervals());

            FiringAllowed = false;
        }
    }
    
    IEnumerator SpawnAtRandomIntervals()
    {
        isSpawning = true;
        
        float randomWaitTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(randomWaitTime);
        
        SpawnPresent(PresentPrefab);
        SpawnPresent(SkullPresentPrefab);

        isSpawning = false; 
        
        FiringAllowed = true;
    }
    
    
    void Start()
    {
        TriggerSpawn();
    }

    void Update()
    {
        
    }
}
