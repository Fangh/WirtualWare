using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayableDirector timerCutscene;
    [SerializeField]
    private TextMeshPro goalText;
    [SerializeField]
    private string[] miniGameScenesName;

    public Action OnLevelLoaded;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene _sceneLoaded, LoadSceneMode arg1)
    {
        OnLevelLoaded?.Invoke();
        if (this != null && _sceneLoaded.buildIndex != 0)
        {
            StartCoroutine(StartCutscene());
        }
    }

    private IEnumerator StartCutscene()
    {
        yield return new WaitForEndOfFrame();
        goalText.text = FindObjectOfType<Objective>().objective;
        timerCutscene.gameObject.SetActive(true);
        timerCutscene.transform.position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
        timerCutscene.Play();
        timerCutscene.stopped += DisableCutscene;

    }

    private void DisableCutscene(PlayableDirector _director)
    {
        timerCutscene.gameObject.SetActive(false);
        timerCutscene.played -= DisableCutscene;
        Invoke("NextLevel", 6f);
    }

    private void NextLevel()
    {
        string nextSceneName = miniGameScenesName[UnityEngine.Random.Range(0, miniGameScenesName.Length)];
        LoadLevel(nextSceneName);
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
