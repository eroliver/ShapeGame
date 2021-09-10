using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text playerHP;
    [SerializeField]
    private TMP_Text enemyHP;


    // Start is called before the first frame update
    void Start()
    {
        playerHP.text = 10.ToString();
        enemyHP.text = 10.ToString();

        SpawnerHealth.OnAttacked += UpdateUI;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int UpdateUI(int health)
    {
        return health;
    }
}
