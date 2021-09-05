using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject roundUnit;
    [SerializeField]
    private GameObject squareUnit;
    [SerializeField]
    private GameObject triUnit;

    private Transform spawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        spawnerTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(roundUnit, spawnerTransform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(squareUnit, spawnerTransform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(triUnit, spawnerTransform);
        }
    }
}
