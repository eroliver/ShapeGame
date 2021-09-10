using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private GameObject menu;

    private void Start()
    {
        GameManager.gameManager.onNextSceneEnter += LoadNextScene;
        GameManager.gameManager.onExitEnter += QuitGame;
        SpawnerHealth.OnAttacked += EndGame;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        menu = this.transform.GetChild(0).gameObject;
    }

    #region NewSceneFunctions
    private void OnEnable()
    {
        
        
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        GameManager.gameManager.onNextSceneEnter -= LoadNextScene;
        GameManager.gameManager.onExitEnter -= QuitGame;
        SpawnerHealth.OnAttacked -= EndGame;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(menu != null)
        {
            if (scene.name == "MainMenu")
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
        
    }

    #endregion




    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex == sceneCount - 1)
        {
            LoadStartScene();
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }


    private void EndGame(int unithealth, GameObject spawner)
    {
        if (spawner.name == "Spawner" && unithealth <= 0)
        {
            Debug.Log("You Lose.");
            LoadStartScene();
        }
        else if(spawner.name == "AISpawner" && unithealth <= 0)
        {
            Debug.Log("You win.");
            LoadStartScene();

        }
    }
}
