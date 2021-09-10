using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class TriUnit : MonoBehaviour
{
    [SerializeField]
    float unitSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
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
            if (hit.transform.gameObject.tag == "paper" || hit.transform.gameObject.tag == "spawner")
            {
                hit.transform.SendMessage("HitByScissors");
            }
    }

    public void HitByRock()
    {
        Destroy(gameObject);
    }
}
