using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundspawner;

    public GameObject coinPrefab;
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
        SpawnCoin();
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

    public void SpawnCoin()
    {
        int spawnAmount = 1;
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject tempCoin = Instantiate(coinPrefab);
            tempCoin.transform.position = SpawnRandomPoint(GetComponent<Collider>());
        }
    }

    Vector3 SpawnRandomPoint(Collider col)
    {
        float[] xOptions = new float[] { 3f, 0, -3f };
        float x = xOptions[Random.Range(0, xOptions.Length)];

        float y = 1;

        float z = Random.Range(col.bounds.min.z, col.bounds.max.z);

        return new Vector3(x, y, z);
    }
}
