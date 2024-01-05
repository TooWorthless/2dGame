using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public void PlayLevel(int level)
    {
        Debug.Log(level);
        SceneManager.LoadScene($"Level {level}");
    }
}
