using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealth : MonoBehaviour
{
    [SerializeField]
    private int unitHealth;
    private GameObject spawner;

    //private Rigidbody rb;

    public delegate void AttackedAction(int health, GameObject spawner);
    public static event AttackedAction OnAttacked;

    public void HitByScissors()
    {
        unitHealth--;
        if(OnAttacked != null)
        {
            OnAttacked(unitHealth, spawner);
            Debug.Log("onattacked by scissors");
        }
        else
        {
            Debug.Log("onattacked is null");
        }
    }
    public void HitByRock()
    {
        unitHealth--;
        if (OnAttacked != null)
        {
            OnAttacked(unitHealth, spawner);
            Debug.Log("onattacked by rock");
        }
    }
    public void HitByPaper()
    {
        unitHealth--;
        if (OnAttacked != null)
        {
            OnAttacked(unitHealth, spawner);
            Debug.Log("onattacked by paper");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
