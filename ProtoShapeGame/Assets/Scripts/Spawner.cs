using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject roundUnit;
    [SerializeField]
    private GameObject squareUnit;
    [SerializeField]
    private GameObject triUnit;
    [SerializeField]
    private float fireRate = 1f;
    private float attackTimer = -1f;

    private InputManager inputManager;

    private Transform spawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        spawnerTransform = gameObject.transform;
        inputManager = GameManager.gameManager.GetComponent<InputManager>();
        inputManager.onSwipeUpEnter += SpawnRock;
        inputManager.onSwipeRightEnter += SpawnPaper;
        inputManager.onSwipeLeftEnter += SpawnScissors;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRock()
    {
        Instantiate(roundUnit, spawnerTransform);
        attackTimer = Time.time + fireRate;
    }

    void SpawnPaper()
    {
        Instantiate(squareUnit, spawnerTransform);
        attackTimer = Time.time + fireRate;
    }

    void SpawnScissors()
    {
        Instantiate(triUnit, spawnerTransform);
        attackTimer = Time.time + fireRate;
    }
}
