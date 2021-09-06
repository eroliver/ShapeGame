using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class AISpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject roundUnit;
    [SerializeField]
    private GameObject squareUnit;
    [SerializeField]
    private GameObject triUnit;
    private GameObject[] units;
    private bool isAttacking;

    private Transform spawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        spawnerTransform = gameObject.transform;
        units = new GameObject[] { roundUnit, squareUnit, triUnit };
        isAttacking = true;
        StartCoroutine("Attacking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attacking()
    {
        while (isAttacking)
        {
            int selectedUnit = Random.Range(0, 3);
            {
                Instantiate(units[selectedUnit], spawnerTransform);
                yield return new WaitForSeconds(1f);
            }
        }
    
    }
}
