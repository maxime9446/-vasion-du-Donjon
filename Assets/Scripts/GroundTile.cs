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
        SpawnObs();
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

    public void SpawnObs()
    {
        int ChooseSpawnPoint = Random.Range(0, spawnpoints.Length);
        int SpawnPrefab = Random.Range(0, obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[SpawnPrefab], spawnpoints[ChooseSpawnPoint].transform.position, Quaternion.identity, transform);
    }
}
