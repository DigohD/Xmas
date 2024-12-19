using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
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
