using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoomManager : MonoBehaviour
{

    private RoomManager _roomMan;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private string mobPrefabFolder; // Folder containing all mob prefabs
    [SerializeField] private float respawnDelay = 2f; // Delay in seconds before respawning a mob at the same spawn point

    private int remainingMobs;

    private GameObject[] mobPrefabs; // Array of mob prefabs to spawn
    private Dictionary<Transform, GameObject> spawnedMobs = new Dictionary<Transform, GameObject>(); // Dictionary to keep track of spawned mobs at each spawn point
    private bool roomEnd = false;
    private bool triggered = false;

    

    private void Start()
    {
        _roomMan = GetComponent<RoomManager>();
        LoadMobPrefabs();
    }

    public void StartRoom()
    {
        triggered = true;
        StartCoroutine(SpawnMobs());
    }
    
    private void LoadMobPrefabs()
    {
        Debug.Log("Loading mob prefabs");
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
        //Needs to be fixed to allow mobs to spawn in waves in the same room.
        //Currently only spawns 1 mob for each spawn point then stops execution.
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

    private void detectMobsInside()
    {

        if ( roomEnd == false )
        {
            //Debug.Log("Searching for mobs in room");
            Collider[] hitColliders = Physics.OverlapBox(transform.position + new Vector3(0, 4, 0), new Vector3(13, 7, 13));
            remainingMobs = 0;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                GameObject hitCollider = hitColliders[i].gameObject;
                if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    remainingMobs += 1;
                    
                }
            }
            //Debug.Log("There are " + remainingMobs + " Enemies left");
            if (remainingMobs == 0)
            {
                _roomMan.OpenDoors();
                enabled = false;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 4, 0), new Vector3(13, 7, 13) );
    }


    private void Update()
    {
        if(triggered)
        {
            detectMobsInside();
        }
    }
}
