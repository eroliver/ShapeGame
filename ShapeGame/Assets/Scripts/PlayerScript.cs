using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerScript : NetworkBehaviour
{
    public TextMesh playerNameText;
    public GameObject floatingInfo;
    private Material playerMaterialClone;
    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;
    [SyncVar(hook = nameof(OnColorChanged))]
    public Color playerColor = Color.white;
    private SharedSceneScript sceneScript;
    private int selectedWeaponLocal = 0;
    [SerializeField]
    private Transform[] spawnLocations;
    [SyncVar(hook = nameof(OnWeaponChanged))]
    public int activeWeaponSynced = 1;

    private string unitName;
    private float unitLife = 10.0f;
    private float unitCooldown = 0.5f;

    private Transform activeSpawnLocation;
    private float weaponCooldownTime;

    private int selectedUnitLocal = 0;
    [SerializeField]
    private GameObject[] unitArray;
    [SyncVar(hook = nameof(OnUnitChanged))]
    public int activeUnitSynced = 1;
    private GameObject unitPrefab;

    void Awake()
    {
        //allow all players to run this
        sceneScript = GameObject.Find("SceneReference").GetComponent<SceneReference>().sceneScript;
        // disable all weapons
        //foreach (var item in spawnLocations)
        //    if (item != null)
        //        item.SetActive(false);
        if (selectedWeaponLocal < spawnLocations.Length && spawnLocations[selectedWeaponLocal] != null)
        {
            activeSpawnLocation = spawnLocations[selectedWeaponLocal].GetComponent<Transform>();
            sceneScript.UIAmmo("PlaceHolder");
        }
    }

    public override void OnStartLocalPlayer()
    {
        sceneScript.playerScript = this;
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 12, 8);
        Camera.main.transform.localRotation = Quaternion.Euler(90, -90, 0);

        floatingInfo.transform.localPosition = new Vector3(0, -0.3f, 0.6f);
        floatingInfo.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        string name = "Player" + Random.Range(100, 999);
        Color color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        CmdSetupPlayer(name, color);
    }

    void Update()
    {
        if (!isLocalPlayer)
        {
            floatingInfo.transform.LookAt(Camera.main.transform);
            return;
        }
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 110.0f;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;
        transform.Rotate(0, moveX, 0);
        transform.Translate(0, 0, moveZ);

        if (Input.GetButtonDown("Fire2")) //Fire2 is mouse 2nd click and left alt
        {
            selectedWeaponLocal += 1;
            if (selectedWeaponLocal >= spawnLocations.Length)
                selectedWeaponLocal = 0;
            CmdChangeActiveWeapon(selectedWeaponLocal);
        }

        if (Input.GetButtonDown("Fire1")) //Fire1 is mouse 1st click
        {
            if (activeSpawnLocation && Time.time > weaponCooldownTime)
            {
                weaponCooldownTime = Time.time + unitCooldown;
                sceneScript.UIAmmo("PlaceHolder");
                CmdShootRay();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnUnit(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnUnit(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnUnit(2);
        }
    }

    private void SpawnUnit(int selectedUnit)
    {
        CmdChangeActiveUnit(selectedUnit);
        if (activeSpawnLocation && Time.time > weaponCooldownTime)
        {
            weaponCooldownTime = Time.time + unitCooldown;
            sceneScript.UIAmmo("PlaceHolder");
            CmdShootRay();
        }
    }

    [Command]
    void CmdShootRay()
    {
        RpcFireWeapon();
    }
    [ClientRpc]
    void RpcFireWeapon()
    {
        //bulletAudio.Play(); muzzleflash  etc
        GameObject unit = Instantiate(unitArray[activeUnitSynced], activeSpawnLocation.transform.position, activeSpawnLocation.transform.rotation);
        unit.layer = gameObject.layer;
        Destroy(unit, unitLife);
    }

    [Command]
    public void CmdSendPlayerMessage()
    {
        if (sceneScript)
            sceneScript.statusText = $"{playerName} says hello {Random.Range(10, 99)}";
    }
    [Command]
    public void CmdSetupPlayer(string _name, Color _col)
    {
        //player info sent to server, then server updates sync vars which handles it on all clients
        playerName = _name;
        playerColor = _col;
        sceneScript.statusText = $"{playerName} joined.";
    }

    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }
    void OnColorChanged(Color _Old, Color _New)
    {
        playerNameText.color = _New;
        playerMaterialClone = new Material(GetComponent<Renderer>().material);
        playerMaterialClone.color = _New;
        GetComponent<Renderer>().material = playerMaterialClone;
    }

    void OnWeaponChanged(int _Old, int _New)
    {
        // disable old weapon
        // in range and not null
        if (0 <= _Old && _Old < spawnLocations.Length && spawnLocations[_Old] != null)
            //spawnLocations[_Old].SetActive(false);

        // enable new weapon
        // in range and not null
        if (0 <= _New && _New < spawnLocations.Length && spawnLocations[_New] != null)
        {
            //spawnLocations[_New].SetActive(true);
            activeSpawnLocation = spawnLocations[activeWeaponSynced].GetComponent<Transform>();
            if (isLocalPlayer)
                sceneScript.UIAmmo(activeSpawnLocation.transform.position.ToString());
        }
    }
    [Command]
    public void CmdChangeActiveWeapon(int newIndex)
    {
        activeWeaponSynced = newIndex;
    }

    ////////////////////////////////////////////////////
    void OnUnitChanged(int _Old, int _New)
    {
        // disable old weapon
        // in range and not null
        if (0 <= _Old && _Old < unitArray.Length && unitArray[_Old] != null)

            // enable new weapon
            // in range and not null
            if (0 <= _New && _New < unitArray.Length && unitArray[_New] != null)
            {
                if (isLocalPlayer)
                    sceneScript.UIAmmo(unitArray[activeUnitSynced].name);
            }
    }
    [Command]
    public void CmdChangeActiveUnit(int newIndex)
    {
        activeUnitSynced = newIndex;
    }

}
