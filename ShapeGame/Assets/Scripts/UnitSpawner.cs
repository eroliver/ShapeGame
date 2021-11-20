using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnLocations;

    [SerializeField]
    private List<GameObject> units;


    private Transform currentSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckSpawnLocations()
    {
        if (spawnLocations.Count == 0)
        {
            foreach (Transform childTransform in gameObject.transform)
            {
                if (childTransform.tag == "spawnLocation")
                {
                    spawnLocations.Add(childTransform);
                }
            }
        }
        if (currentSpawnLocation == null)
        {
            currentSpawnLocation = spawnLocations[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChooseSpawnLocation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpawnLocation = spawnLocations[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpawnLocation = spawnLocations[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpawnLocation = spawnLocations[2];
        }
    }

    public GameObject SpawnUnit(int unitIndex)
    {
        GameObject unitInstance = Instantiate(units[unitIndex], currentSpawnLocation.position, currentSpawnLocation.rotation);
        unitInstance.layer = gameObject.layer;
        return unitInstance;
    }


}
