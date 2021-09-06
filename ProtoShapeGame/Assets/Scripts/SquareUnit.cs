using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class SquareUnit : MonoBehaviour
{
    float unitSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        unitSpeed = 0.01f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveUnit();
        Attack();
    }

    private void moveUnit()
    {
        transform.Translate(Vector3.left * unitSpeed);
        rb.detectCollisions = true;
    }

    
    private void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 0.5f))
            if (hit.transform.gameObject.tag == "rock")
            {
                hit.transform.SendMessage("HitByPaper");
            }
    }

    public void HitByScissors()
    {
        Destroy(gameObject);
    }
}
