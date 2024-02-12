using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundspawner;

    public GameObject[] obstaclePrefabs;
    public Transform[] spawnpoints;

    private void Awake()
    {
        groundspawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        groundspawner.spawnTile();

        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
