using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public static GameManager Instance;
    public ScoreManager scoreManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log($"There is no Game Manager is the scene. {gameObject.name} is now the GameManager");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
