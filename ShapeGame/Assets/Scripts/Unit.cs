using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Unit : NetworkBehaviour
{
    [SerializeField]
    private float unitSpeed = 0.1f;
    [SerializeField]
    public UnitTypes unitType;

    public enum UnitTypes
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
        transform.Translate(Vector3.forward * unitSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.GetComponent<Unit>())
        {
            ResolveFight(collision.gameObject.GetComponent<Unit>().unitType);
        }
        if (collision.gameObject.GetComponent<UnitSpawner>())
        {
            //hit animation?
        }
    }

    private void ResolveFight(UnitTypes hitUnit)
    {
        switch (unitType)
        {
            case UnitTypes.rock:
                if (hitUnit == UnitTypes.rock)
                {
                    Die();
                }
                if (hitUnit == UnitTypes.paper)
                {
                    Die();
                }
                if (hitUnit == UnitTypes.scissors)
                {
                    //kill animation?
                    break;
                }
                break;
            case UnitTypes.paper:
                if (hitUnit == UnitTypes.rock)
                {
                    //kill anim?
                    break;
                }
                if (hitUnit == UnitTypes.paper)
                {
                    Die();
                }
                if (hitUnit == UnitTypes.scissors)
                {
                    Die();
                }
                break;
            case UnitTypes.scissors:
                if (hitUnit == UnitTypes.rock)
                {
                    Die();
                }
                if (hitUnit == UnitTypes.paper)
                {
                    //kill anim?
                    break;
                }
                if (hitUnit == UnitTypes.scissors)
                {
                    Die();
                }
                break;
            default:
                break;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
