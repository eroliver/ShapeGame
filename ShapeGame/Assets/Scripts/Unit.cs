using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float unitSpeed;
    [SerializeField]
    UnitTypes unitType;

    private enum UnitTypes
    {
        rock,
        paper,
        scissors
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveUnit();
    }

    private void MoveUnit()
    {
        transform.Translate(Vector3.forward * unitSpeed);
    }
}
