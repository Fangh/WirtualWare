using System;
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

    public Action OnLevelLoaded;

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene _sceneLoaded, LoadSceneMode arg1)
    {
        OnLevelLoaded?.Invoke();
        try
        {
            if (_sceneLoaded.buildIndex != 0)
            {
                goalText.text = FindObjectOfType<Objective>().objective;
                timerCutscene.gameObject.SetActive(true);
                timerCutscene.transform.parent = GameObject.FindGameObjectWithTag("MainCamera").transform;
                timerCutscene.transform.localPosition = Vector3.zero;
                timerCutscene.Play();
                timerCutscene.played += DisableCutscene;
            }
        }
        catch
        {
            Debug.LogError("You might have forgotten to put an Objective gameobject in this scene");
        }
    }

    private void DisableCutscene(PlayableDirector _director)
    {
        timerCutscene.transform.parent = transform;
        timerCutscene.transform.localPosition = Vector3.zero;
        timerCutscene.gameObject.SetActive(false);
        timerCutscene.played -= DisableCutscene;
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
