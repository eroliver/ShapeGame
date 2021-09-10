using UnityEngine;

[SelectionBase]
public class RoundUnit : MonoBehaviour
{
    [SerializeField]
    private float unitSpeed;
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
            if (hit.transform.gameObject.tag == "scissors" || hit.transform.gameObject.tag == "spawner")
            {
                hit.transform.SendMessage("HitByRock");
            }
    }
    
    public void HitByPaper()
    {
        Destroy(gameObject);
    }
}
