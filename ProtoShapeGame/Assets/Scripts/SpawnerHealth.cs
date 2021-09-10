using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealth : MonoBehaviour
{
    [SerializeField]
    private int unitHealth;

    public delegate int AttackedAction(int health);
    public static event AttackedAction OnAttacked;

    public void HitByScissors()
    {
        unitHealth--;
        if(OnAttacked != null)
        {
            OnAttacked(unitHealth);
        }
    }
    public void HitByRock()
    {
        unitHealth--;
        if (OnAttacked != null)
        {
            OnAttacked(unitHealth);
        }
    }
    public void HitByPaper()
    {
        unitHealth--;
        if (OnAttacked != null)
        {
            OnAttacked(unitHealth);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
