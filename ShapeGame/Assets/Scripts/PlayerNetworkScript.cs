using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerNetworkScript : NetworkBehaviour
{
    [SerializeField]
    private UnitSpawner spawner;

    public TextMesh playerNameText;
    public GameObject floatingInfo;
    private Material playerMaterialClone;
    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;
    [SyncVar(hook = nameof(OnColorChanged))]
    public Color playerColor = Color.white;
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawner == null)
        {
            spawner = GetComponentInChildren<UnitSpawner>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        spawner.ChooseSpawnLocation();
        spawner.SpawnUnit();
    }

    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }
    void OnColorChanged(Color _Old, Color _New)
    {
        playerNameText.color = _New;
        playerMaterialClone = new Material(GetComponentInChildren<Renderer>().material);
        //playerMaterialClone = new Material(GetComponent<Renderer>().material);
        playerMaterialClone.color = _New;
        //GetComponent<Renderer>().material = playerMaterialClone;
    }
    public override void OnStartLocalPlayer()
    {
        spawner.CheckSpawnLocations();
        floatingInfo.transform.localPosition = new Vector3(-35, 10, 0);
        //floatingInfo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        string name = "Player" + Random.Range(100, 999);
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        CmdSetupPlayer(name, color);
    }
    [Command]
    public void CmdSetupPlayer(string _name, Color _col)
    {
        // player info sent to server, then server updates sync vars which handles it on all clients
        playerName = _name;
        playerColor = _col;
    }

}
