using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(Object scene)
    {
        GameManager.Instance.levelManager.LoadLevel(scene.name);
    }
}
