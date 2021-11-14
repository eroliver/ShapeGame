using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> spawnLocations;
    [SerializeField]
    private GameObject rockUnit;
    [SerializeField]
    private GameObject paperUnit;
    [SerializeField]
    private GameObject scissorsUnit;

    private Transform currentSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChooseSpawnLocation();
        SpawnUnit();
    }

    void ChooseSpawnLocation()
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

    void SpawnUnit()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(rockUnit, currentSpawnLocation.position, currentSpawnLocation.rotation);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(paperUnit, currentSpawnLocation.position, currentSpawnLocation.rotation);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(scissorsUnit, currentSpawnLocation.position, currentSpawnLocation.rotation);
        }
    }
}
