using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public static GameManager Instance;
    public ScoreManager scoreManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

}
