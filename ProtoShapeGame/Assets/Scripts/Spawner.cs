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


    private Transform spawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        spawnerTransform = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > attackTimer)
        {
            Instantiate(roundUnit, spawnerTransform);
            attackTimer = Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time > attackTimer)
        {
            Instantiate(squareUnit, spawnerTransform);
            attackTimer = Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.time > attackTimer)
        {
            Instantiate(triUnit, spawnerTransform);
            attackTimer = Time.time + fireRate;
        }
    }
}
