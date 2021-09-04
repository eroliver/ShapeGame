using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundUnit : MonoBehaviour
{
    float unitSpeed;

    // Start is called before the first frame update
    void Start()
    {
        unitSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        moveUnit();
    }

    private void moveUnit()
    {
        transform.Translate(Vector3.left * unitSpeed);
    }
}
