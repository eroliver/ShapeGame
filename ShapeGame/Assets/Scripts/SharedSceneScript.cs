using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using UnityEngine.SceneManagement;

public class SharedSceneScript : NetworkBehaviour
{
    public SceneReference sceneReference;
    public Text canvasStatusText;
    public PlayerScript playerScript;
    [SyncVar(hook = nameof(OnStatusTextChanged))]
    public string statusText;
    void OnStatusTextChanged(string _Old, string _New)
    {
        //called from sync var hook, to update info on screen for all players
        canvasStatusText.text = statusText;
    }
    public void ButtonSendMessage()
    {
        if (playerScript != null)
            playerScript.CmdSendPlayerMessage();
    }

    public void ButtonChangeScene()
    {
        if (isServer)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "1LaneLevel")
                NetworkManager.singleton.ServerChangeScene("3LaneLevel");
            else
                NetworkManager.singleton.ServerChangeScene("1LaneLevel");
        }
        else
            Debug.Log("You are not Host.");
    }

    //maybe change this to display the currently selected unit or location
    public Text canvasAmmoText;

    public void UIAmmo(int _value)
    {
        canvasAmmoText.text = "Ammo: " + _value;
    }
}
