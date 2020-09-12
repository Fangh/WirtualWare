using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Object firstScene;

    private Scene currentScene;

    public void Start()
    {
        LoadLevel(firstScene.name);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        currentScene = SceneManager.GetActiveScene();
    }
}
