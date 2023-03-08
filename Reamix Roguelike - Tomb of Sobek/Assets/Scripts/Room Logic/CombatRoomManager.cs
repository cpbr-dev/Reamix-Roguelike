using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoomManager : MonoBehaviour
{
    [SerializeField] private int mobQuantity;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private string mobPrefabFolder; // Folder containing all mob prefabs
    [SerializeField] private float respawnDelay = 2f; // Delay in seconds before respawning a mob at the same spawn point

    private GameObject[] mobPrefabs; // Array of mob prefabs to spawn
    private Dictionary<Transform, GameObject> spawnedMobs = new Dictionary<Transform, GameObject>(); // Dictionary to keep track of spawned mobs at each spawn point

    private bool triggered = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (triggered) return;
        triggered = true;
        StartCoroutine(SpawnMobs());
    }

    private void Start()
    {
        LoadMobPrefabs();
    }

    private void LoadMobPrefabs()
    {
        if (string.IsNullOrEmpty(mobPrefabFolder))
        {
            Debug.LogError("Mob prefab folder path not set!");
            return;
        }

        Object[] prefabObjects = Resources.LoadAll(mobPrefabFolder, typeof(GameObject));

        if (prefabObjects.Length == 0)
        {
            Debug.LogError("No mob prefabs found in folder!");
            return;
        }

        mobPrefabs = new GameObject[prefabObjects.Length];

        for (int i = 0; i < prefabObjects.Length; i++)
        {
            GameObject prefab = prefabObjects[i] as GameObject;

            if (prefab == null)
            {
                Debug.LogError($"Object at index {i} is not a GameObject!");
                continue;
            }

            mobPrefabs[i] = prefab;
        }
    }

    private IEnumerator SpawnMobs()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint == null)
            {
                Debug.LogWarning("Null spawn point found!");
                continue;
            }

            if (spawnedMobs.ContainsKey(spawnPoint))
            {
                GameObject existingMob = spawnedMobs[spawnPoint];

                if (existingMob != null)
                {
                    yield return new WaitForSeconds(respawnDelay);

                    if (spawnedMobs.ContainsKey(spawnPoint)) // Check again in case the spawn point was cleared while waiting
                    {
                        existingMob = spawnedMobs[spawnPoint];
                    }

                    if (existingMob != null) // Check again in case the mob was destroyed while waiting
                    {
                        continue; // Skip to next spawn point
                    }
                }
            }

            int mobIndex = Random.Range(0, mobPrefabs.Length);
            GameObject mobPrefab = mobPrefabs[mobIndex];

            GameObject mob = Instantiate(mobPrefab, spawnPoint.position, Quaternion.identity);
            spawnedMobs[spawnPoint] = mob;
        }
    }

}
