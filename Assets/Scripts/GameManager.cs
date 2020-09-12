using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    public static GameManager Instance;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

}
