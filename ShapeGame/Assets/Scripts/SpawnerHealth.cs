using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        health--;
    }
}
